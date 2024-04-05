using LeafCast.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace LeafCast.API.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TobaccoGrade>? TobaccoGrades { get; set; }
}