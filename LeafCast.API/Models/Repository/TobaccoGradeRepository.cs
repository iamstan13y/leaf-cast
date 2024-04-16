using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;

namespace LeafCast.API.Models.Repository;

public class TobaccoGradeRepository(AppDbContext context) : ITobaccoGradeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Result<bool>> AddRangeAsync(List<TobaccoGrade> tobaccoGrades)
    {

        await _context.TobaccoGrades!.AddRangeAsync(tobaccoGrades);
        await _context.SaveChangesAsync();

        return new Result<bool>(true, "Data saved successfully!");
    }
}