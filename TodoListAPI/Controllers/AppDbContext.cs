using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Controllers;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<TodoListTask> Tasks { get; set; }
}
