using LeafCast.API.Models.Data;

namespace LeafCast.API.Models.Repository;

public class PredictionRepository(AppDbContext context) : IPredictionRepository
{
    private readonly AppDbContext _context = context;

    public async Task<bool> AddBulkAsync(IEnumerable<Prediction> predictions)
    {
        await _context.Predictions!.AddRangeAsync(predictions);
        await context.SaveChangesAsync();
        
        return true;
    }
}