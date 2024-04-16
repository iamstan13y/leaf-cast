using LeafCast.API.Models.Data;

namespace LeafCast.API.Models.Repository;

public interface IPredictionRepository
{
    Task<bool> AddBulkAsync(IEnumerable<Prediction> predictions);
}