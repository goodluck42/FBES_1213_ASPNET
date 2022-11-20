using ASPNET_HTML_HELPERSApplication.Models;

namespace ASPNET_HTML_HELPERSApplication.Services;

public interface IProductManager : IEnumerable<Product>
{
	Task<bool> AddProductAsync(Product product);
	Task<bool> RemoveProductAsync(int id);
	Task<Product?> GetProductByIdAsync(int? id);
}
