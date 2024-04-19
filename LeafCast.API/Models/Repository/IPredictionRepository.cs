using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;

namespace LeafCast.API.Models.Repository;

public interface IPredictionRepository
{
    Task<bool> AddBulkAsync(List<PredictionRequest> predictions);
    Task<Result<IEnumerable<Prediction>>> GetAllAsync();
}