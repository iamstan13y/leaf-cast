using LeafCast.Models.Data;
using LeafCast.Models.Local;

namespace LeafCast.Services;

public interface IHttpService
{
    Task<Result<Dictionary<string, decimal>>> GetTopGradesAsync();
    Task<Result<User>> CreateAccountAsync(CreateAccountRequest request);
}