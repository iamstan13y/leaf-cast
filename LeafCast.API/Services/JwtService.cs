using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LeafCast.API.Models.Data;

namespace LeafCast.API.Services
{
    public class JwtService(IConfiguration configuration) : IJwtService
    {
        public Task<string> GenerateTokenAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JwtService:Secret"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new("UserId", user.Id.ToString()),
                    new(ClaimTypes.Email, user.PhoneNumber!),
                    new(ClaimTypes.Role, user.UserName!)
                }),

                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return Task.FromResult(user.Token);
        }
    }
}