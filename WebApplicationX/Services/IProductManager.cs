using WebApplicationX.Models;

namespace WebApplicationX.Services
{
    public interface IProductManager
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        bool RemoveProduct(int index);
        Product? GetProductByIndex(int index);

	}
}
