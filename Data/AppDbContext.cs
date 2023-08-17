using Microsoft.EntityFrameworkCore;
using deployWebAPI.Models;

namespace deployWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Weather> WeatherData { get; set; }
    }
}