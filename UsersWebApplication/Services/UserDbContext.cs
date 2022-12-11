using Bogus;

using Microsoft.EntityFrameworkCore;

using WebApiLibrary;

namespace UsersWebApplication.Services
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int id = 1;
            var faker = new Faker<User>();
            var users = faker.RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.CreationDate, f => f.Date.Between(DateTime.Now, DateTime.Now))
                .RuleFor(u => u.Id, () => id++).Generate(10);


            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
