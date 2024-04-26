namespace LeafCast.API.Models.Local;

public class CreateAccountRequest
{
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}