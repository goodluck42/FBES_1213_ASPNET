using DTOMappingWebApplication.Entities;

using Microsoft.EntityFrameworkCore;

namespace DTOMappingWebApplication.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(entity => entity.Id);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.Login).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
        });
    }
}
