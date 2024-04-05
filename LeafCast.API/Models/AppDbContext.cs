using Microsoft.EntityFrameworkCore;

namespace LeafCast.API.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}