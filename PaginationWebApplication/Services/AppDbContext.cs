using Bogus;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var faker = new Faker<Product>();

        int i = 1;
        var collection = faker.RuleFor(p => p.Name, f => f.Commerce.Product()).RuleFor(p => p.Quantity, _ => Random.Shared.Next(2, 16)).RuleFor(p => p.Id, _ => i++).Generate(16);

        modelBuilder.Entity<Product>().HasData(collection);
    }
}
