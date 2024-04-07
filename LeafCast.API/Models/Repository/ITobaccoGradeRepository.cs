using LeafCast.API.Models.Data;

namespace LeafCast.API.Models.Repository;

public interface ITobaccoGradeRepository
{
    Task<bool> AddRangeAsync(List<TobaccoGrade> tobaccoGrades);
}