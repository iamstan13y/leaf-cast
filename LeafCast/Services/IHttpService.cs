using LeafCast.Models.Local;

namespace LeafCast.Services;

public interface IHttpService
{
    Task<Result<Dictionary<string, decimal>>> GetTopGradesAsync();
}