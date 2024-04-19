using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;

namespace LeafCast.API.Models.Repository;

public class TobaccoGradeRepository(AppDbContext context) : ITobaccoGradeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Result<bool>> AddBulkAsync(List<GradeRequest> tobaccoGrades)
    {
        tobaccoGrades.ForEach(async grade =>
        {
            await _context.TobaccoGrades!.AddAsync(new TobaccoGrade
            {
                Name = grade.Name
            });
        });

        await _context.SaveChangesAsync();

        return new Result<bool>(true, "Data saved successfully!");
    }
}