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
}