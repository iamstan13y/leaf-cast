using LeafCast.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace LeafCast.API.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TobaccoGrade>? TobaccoGrades { get; set; }
    public DbSet<Prediction>? Predictions { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<OtpCode>? OtpCodes { get; set; }
}