using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;

namespace LeafCast.API.Models.Repository;

public interface IUserRepository
{
    Task<Result<User>> LoginAsync(LoginRequest request);
    Task<Result<User>> AddAsync(User user);
    //Task<Result<Account>> ChangePasswordAsync(ChangePasswordRequest changePasswordRequest);
    //Task<Result<string>> GetResetPasswordCodeAsync(string email);
    //Task<Result<Account>> ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest);
    //Task<Result<Account>> ConfirmAccountAsync(ConfirmAccountRequest confirmAccountRequest);
    //Task<Result<string>> ResendOtpAsync(string email);
}