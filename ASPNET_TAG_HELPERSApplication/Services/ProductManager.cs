using ASPNET_HTML_HELPERSApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ASPNET_HTML_HELPERSApplication.Services;

public class ProductManager : IProductManager
{
	private readonly ProductDbContext _dbContext;

	public ProductManager(ProductDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Product?> GetProductByIdAsync(int? id)
	{
		if (id == null)
		{
			return null;
		}

		return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
	}

	public async Task<bool> AddProductAsync(Product product)
	{
		try
		{
			await _dbContext.Products.AddAsync(product);
			await _dbContext.SaveChangesAsync();

			return true;
		}
		catch
		{
			return false;
		}
	}

	public IEnumerator<Product> GetEnumerator()
	{
		foreach (var product in _dbContext.Products)
		{
			yield return product;
		}
	}

	public async Task<bool> RemoveProductAsync(int id)
	{
		try
		{
			var result = await GetProductByIdAsync(id);

			if (result != null)
			{
				_dbContext.Products.Remove(result);

				await _dbContext.SaveChangesAsync();

				return true;
			}

			return false;
		}
		catch
		{
			return false;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
