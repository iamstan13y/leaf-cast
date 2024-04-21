using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;
using LeafCast.API.Services;
using Microsoft.EntityFrameworkCore;

namespace LeafCast.API.Models.Repository;

public class UserRepository
    (AppDbContext context,
    IConfiguration configuration,
    IPasswordService passwordService, 
    IJwtService jwtService, 
    ICodeGeneratorService codeGeneratorService, 
    ISmsService smsService) : IUserRepository
{
    private readonly AppDbContext _context = context;
    private readonly IConfiguration _configuration = configuration;
    private readonly IPasswordService _passwordService = passwordService;
    private readonly IJwtService _jwtService = jwtService;
    private readonly ICodeGeneratorService _codeGeneratorService = codeGeneratorService;
    private readonly ISmsService _smsService = smsService;

    public async Task<Result<User>> AddAsync(User user)
    {
        try
        {
            if (!IsUniqueUser(user.UserName!))
                return new Result<User>(false, "An account with that username already exists!");

            await _context.Users!.AddAsync(user);

            var code = await _codeGeneratorService.GenerateMobileOtpCode();

            await _context.OtpCodes!.AddAsync(new OtpCode
            {
                Code = code,
                PhoneNumber = user.PhoneNumber
            });

            await _smsService.SendAsync(new SmsRequest
            {
                PhoneNumber = user.PhoneNumber,
                Message = $"Your account has been created successfully. Your OTP code for verification is: {code}"
            });

            await _context.SaveChangesAsync();

            return new Result<User>(user, "Account created successfully!");
        }
        catch (Exception ex)
        {
            return new Result<User>(false, ex.ToString());
        }
    }

    //public async Task<Result<Account>> ConfirmAccountAsync(ConfirmAccountRequest request)
    //{
    //    var account = await _dbSet
    //        .Where(x => x.Email == request.Email)
    //        .FirstOrDefaultAsync();
    //    if (account == null) return new Result<Account>(false, "User account not found!");

    //    var code = await _context.OtpCodes!
    //        .Where(x => x.Email == request.Email && x.Code == request.OtpCode)
    //        .FirstOrDefaultAsync();

    //    if (code == null) return new Result<Account>(false, "Invalid code provided!");

    //    account.Password = _passwordService.HashPassword(request.Password!);
    //    account.IsActive = true;

    //    _dbSet.Update(account);

    //    await _context.SaveChangesAsync();

    //    return new Result<Account>(account, "Your account has been activated!");
    //}

    public async Task<Result<User>> LoginAsync(LoginRequest request)
    {
        var user = await _context
            .Users!
            .Where(x => x.UserName == request.UserName)
            .FirstOrDefaultAsync();

        if (user == null || !_passwordService.VerifyHash(request.Password!, user!.Password!))
            return new Result<User>(false, "Username or password is incorrect!");

        if (!user.IsActive) return new Result<User>(false, "This account is inactive!");

        user.Token = await _jwtService.GenerateTokenAsync(user);

        user.Password = "***********";

        return new Result<User>(user);
    }

    private bool IsUniqueUser(string userName)
    {
        var user = _context.Users!.SingleOrDefault(x => x.UserName == userName);

        if (user == null) return true;
        return false;
    }

    //public async Task<Result<Account>> ChangePasswordAsync(ChangePasswordRequest changePassword)
    //{
    //    var account = await FindAsync(changePassword.UserId);
    //    if (!account.Success) return account;

    //    if (_passwordService.VerifyHash(changePassword.OldPassword!, account.Data!.Password!) == false)
    //        return new Result<Account>(false, "Old password mismatch");

    //    account.Data.Password = _passwordService.HashPassword(changePassword.NewPassword!);

    //    _dbSet.Update(account.Data);
    //    await _context.SaveChangesAsync();

    //    return new Result<Account>(account.Data);
    //}

    //public async Task<Result<string>> ResendOtpAsync(string email)
    //{
    //    var account = await _dbSet.Where(x => x.Email!.Equals(email)).FirstOrDefaultAsync();
    //    if (account == null) return new Result<string>(false, "Please ensure you have recently created an account!");

    //    var otpCode = await _context.OtpCodes!.Where(x => x.Email == email && x.DateCreated.AddMinutes(5) >= DateTime.Now).FirstOrDefaultAsync();

    //    if (otpCode == null)
    //    {
    //        otpCode!.Code = await _codeGeneratorService.GenerateVerificationCode();

    //        await _context.OtpCodes!.AddAsync(new OtpCode
    //        {
    //            Code = otpCode!.Code,
    //            Email = email
    //        });

    //        await _context.SaveChangesAsync();
    //    }

    //    var emailResult = await _emailService.SendEmailAsync(new EmailRequest
    //    {
    //        Body = string.Format(_configuration["EmailService:ResetCodeBody"], otpCode!.Code),
    //        Subject = _configuration["EmailService:ResetCodeSubject"],
    //        To = email
    //    });

    //    if (!emailResult.Success) return new Result<string>(false, "Failed to send OTP to email.");

    //    return new Result<string>("OTP code has been sent to your email.");
    //}

    //public async Task<Result<string>> GetResetPasswordCodeAsync(string email)
    //{
    //    var account = await _dbSet.SingleOrDefaultAsync(y => y.Email == email);
    //    if (account == null) return new Result<string>(false, "User account does not exist.");

    //    var code = await _codeGeneratorService.GenerateVerificationCode();

    //    await _context.OtpCodes!.AddAsync(new OtpCode
    //    {
    //        Code = code,
    //        Email = account.Email
    //    });

    //    await _context.SaveChangesAsync();

    //    var emailResult = await _emailService.SendEmailAsync(new EmailRequest
    //    {
    //        Body = string.Format(_configuration["EmailService:ResetCodeBody"], code),
    //        Subject = _configuration["EmailService:ResetCodeSubject"],
    //        To = account.Email
    //    });

    //    if (!emailResult.Success) return new Result<string>("Verification code has been sent to your email.");

    //    return new Result<string>("Verification code has been sent to your email.");
    //}

    //public async Task<Result<Account>> ResetPasswordAsync(ResetPasswordRequest request)
    //{
    //    var account = await _dbSet.Where(x => x.Email == request.UserEmail).FirstOrDefaultAsync();
    //    if (account == null) return new Result<Account>(false, "Whoaa! How did you get here?");

    //    var verifyCode = await _context.OtpCodes!
    //        .Where(x => x.Email == account.Email &&
    //        x.DateCreated.AddMinutes(5) >= DateTime.Now &&
    //        x.Code == request.OtpCode)
    //        .FirstOrDefaultAsync();

    //    if (verifyCode == null) return new Result<Account>(false, "Invalid password reset code provided.");

    //    account!.Password = _passwordService.HashPassword(request.NewPassword!);

    //    _dbSet.Update(account);
    //    await _context.SaveChangesAsync();

    //    return new Result<Account>(account, "Your password has been reset successfully.");
    //}
}