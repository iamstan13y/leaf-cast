using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;
using Microsoft.EntityFrameworkCore;

namespace LeafCast.API.Models.Repository;

public class PredictionRepository(AppDbContext context) : IPredictionRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Result<bool>> AddBulkAsync(List<PredictionRequest> predictions)
    {
        predictions.ForEach(async prediction =>
        {
            await _context.Predictions!.AddAsync(new Prediction
            {
                TobaccoGradeId = prediction.TobaccoGradeId,
                Year = prediction.Year,
                ActualPrice = prediction.ActualPrice,
                PredictedPrice = prediction.PredictedPrice,
            });
        });

        await context.SaveChangesAsync();

        return new Result<bool>(true);
    }

    public async Task<Result<IEnumerable<Prediction>>> GetAllAsync() =>
        new Result<IEnumerable<Prediction>>(await _context.Predictions!.Include(x => x.TobaccoGrade).ToListAsync());

    public async Task<Result<Dictionary<string, decimal>>> GetTopGradesAsync()
    {
        var grades = await _context.Predictions!.Where(x => x.Year == DateTime.Now.AddYears(-1).Year)
            .GroupBy(x => x.TobaccoGrade.Name)
            .Select(x => new
            {
                Grade = x.Key,
                TotalPrice = x.Sum(x => x.ActualPrice)
            })
            .OrderByDescending(x => x.TotalPrice)
            .Take(5)
            .ToListAsync();

        var total = grades.Sum(x => x.TotalPrice);

        var gradesWithPercentage = grades.ToDictionary(x => x.Grade, x => Math.Round((x.TotalPrice / total) * 100, 2));

        return new Result<Dictionary<string, decimal>>(gradesWithPercentage);
    }


}