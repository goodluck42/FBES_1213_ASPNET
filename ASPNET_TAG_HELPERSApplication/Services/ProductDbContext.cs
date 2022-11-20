using ASPNET_HTML_HELPERSApplication.Models;

using Microsoft.EntityFrameworkCore;

namespace ASPNET_HTML_HELPERSApplication.Services
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Product> Products { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
			
		//}
	}
}
