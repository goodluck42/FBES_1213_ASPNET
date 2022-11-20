using ASPNET_HTML_HELPERSApplication.Models;
using ASPNET_HTML_HELPERSApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_HTML_HELPERSApplication.Controllers;

public class ProductController : Controller
{
	private readonly IProductManager _productManager;

	public ProductController(IProductManager productManager)
	{
		_productManager = productManager;
	}

	public IActionResult Index()
	{
		return View(_productManager);
	}

	[HttpPost]
	[HttpGet]
	public async Task<IActionResult> Add([FromForm] Product? product)
	{
		if (HttpContext.Request.Method == HttpMethod.Get.Method || product == null)
		{
			return View();
		}

		await _productManager.AddProductAsync(product);

		return RedirectToAction("Index");
	}

	[HttpPost]
	[HttpGet]
	public async Task<IActionResult> Remove(int? id)
	{
		if (HttpContext.Request.Method == HttpMethod.Get.Method || id == null)
		{
			return View();
		}

		await _productManager.RemoveProductAsync((int)id);

		return RedirectToAction("Index");
	}

	[HttpGet]
	public async Task<IActionResult> Get(int? id)
	{
		return View(await _productManager.GetProductByIdAsync(id));
	}
}
