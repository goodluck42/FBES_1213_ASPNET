using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RBACWebApplication.Services
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
