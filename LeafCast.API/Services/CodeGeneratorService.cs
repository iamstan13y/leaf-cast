using System.Text;

namespace LeafCast.API.Services;

public class CodeGeneratorService(IConfiguration configuration) : ICodeGeneratorService
{
    private readonly IConfiguration _configuration = configuration;

    public Task<string> GenerateVerificationCode()
    {
        var characters = _configuration["GeneratorService:Characters"];
        var numerals = _configuration["GeneratorService:Numerals"];

        var sequence = characters.Concat(numerals).ToList();
        var code = new StringBuilder();
        var rnd = new Random();

        for (int i = 0; i < 6; i++)
        {
            code.Append(sequence[rnd.Next(sequence.Count - 1)]);
        }

        return Task.FromResult(code.ToString());
    }

    public Task<string> GenerateReferenceCode()
    {
        string dateTime = DateTime.Now.ToString("yyMMddHHmm");

        Random rnd = new();
        char randomLetter = (char)('A' + rnd.Next(26));

        string referenceCode = $"VEF00{dateTime}{randomLetter}";

        return Task.FromResult(referenceCode);
    }

    public Task<string> GenerateMobileOtpCode()
    {
        Random random = new();
        int otp = random.Next(100000, 999999);

        string otpCode = otp.ToString();
        return Task.FromResult(otpCode);
    }
}