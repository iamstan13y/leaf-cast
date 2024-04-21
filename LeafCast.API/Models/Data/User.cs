using System.ComponentModel.DataAnnotations.Schema;

namespace LeafCast.API.Models.Data;

public class User
{
    public int Id { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public bool IsActive { get; set; } = false;
    [NotMapped]
    public string? Token { get; set; }
}