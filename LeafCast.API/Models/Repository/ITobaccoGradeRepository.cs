using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;

namespace LeafCast.API.Models.Repository;

public interface ITobaccoGradeRepository
{
    Task<Result<bool>> AddBulkAsync(List<GradeRequest> tobaccoGrades);
    Task<Result<IEnumerable<TobaccoGrade>>> GetAllAsync();
    Task<Result<TobaccoGrade>> GetByIdAsync(int id);
}