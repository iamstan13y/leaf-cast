namespace LeafCast.API.Services;

public interface ICodeGeneratorService
{
    Task<string> GenerateVerificationCode();
    Task<string> GenerateReferenceCode();
    Task<string> GenerateMobileOtpCode();
}