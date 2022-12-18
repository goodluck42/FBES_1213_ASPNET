using AuthWebApplication.Models;

using Microsoft.EntityFrameworkCore;

namespace AuthWebApplication.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
