using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;

namespace LeafCast.API.Models.Repository;

public interface IPredictionRepository
{
    Task<Result<bool>> AddBulkAsync(List<PredictionRequest> predictions);
    Task<Result<IEnumerable<Prediction>>> GetAllAsync();
    Task<Result<Dictionary<string, decimal>>> GetTopGradesAsync();
}