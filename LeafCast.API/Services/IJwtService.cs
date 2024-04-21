using LeafCast.API.Models.Data;

namespace LeafCast.API.Services;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(User user);
}