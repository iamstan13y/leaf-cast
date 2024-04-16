using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;

namespace LeafCast.API.Models.Repository;

public interface ITobaccoGradeRepository
{
    Task<Result<bool>> AddRangeAsync(List<TobaccoGrade> tobaccoGrades);
}