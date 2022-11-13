using WebApplicationX.Models;

namespace WebApplicationX.Services
{
	public class ProductManager : IProductManager
	{
		private static List<Product> s_Products = new List<Product>
		{
			new(1, "Banana", 42, 5),
			new(2, "Cucumber", 30, 10),
			new(3, "Lemon", 50, 3)
		};

		public void AddProduct(Product product)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> GetProducts()
		{
			return s_Products;
		}

		public Product? GetProductByIndex(int index)
		{
			try
			{
				return s_Products[index];
			}
			catch (ArgumentOutOfRangeException)
			{
				return null;
			}
		}

		public bool RemoveProduct(int index)
		{
			try
			{
				s_Products.RemoveAt(index);

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
