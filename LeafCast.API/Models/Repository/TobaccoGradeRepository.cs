using LeafCast.API.Models.Data;

namespace LeafCast.API.Models.Repository;

public class TobaccoGradeRepository(AppDbContext context) : ITobaccoGradeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<bool> AddRangeAsync(List<TobaccoGrade> tobaccoGrades)
    {

        await _context.TobaccoGrades!.AddRangeAsync(tobaccoGrades);
        await _context.SaveChangesAsync();

        return true;
    }
}
