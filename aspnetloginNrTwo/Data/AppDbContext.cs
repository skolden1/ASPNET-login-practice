using aspnetloginNrTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetloginNrTwo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
