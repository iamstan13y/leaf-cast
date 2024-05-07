using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Result<IEnumerable<TobaccoGrade>>> GetAllAsync() =>
        new Result<IEnumerable<TobaccoGrade>>(await _context.TobaccoGrades!.ToListAsync());

    public async Task<Result<TobaccoGrade>> GetByIdAsync(int id)
    {
        var grade = await _context.TobaccoGrades!.FindAsync(id);

        if (grade == null) return new Result<TobaccoGrade>(false, "Grade not found.");

        return new Result<TobaccoGrade>(grade);
    }
}