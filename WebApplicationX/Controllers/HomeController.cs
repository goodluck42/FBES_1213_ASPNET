using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

using System.Diagnostics;
using System.Text.Json;

using WebApplicationX.Models;
using WebApplicationX.Services;

namespace WebApplicationX.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProductManager _productManager;

		public HomeController(ILogger<HomeController> logger, IProductManager productManager)
		{
			_logger = logger;
			_productManager = productManager;
		}

		public IActionResult Index(int index = 0)
		{
			return View(_productManager.GetProductByIndex(index));
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[HttpGet]
		public IActionResult GetProduct(int? number)
		{
			if (number == null || number == 0)
			{
				return NotFound();
			}

			var product = _productManager.GetProductByIndex(number.Value - 1);

			if (product == null)
			{
				return NotFound();
			}

			string data = JsonSerializer.Serialize(product);

			return Ok(data);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}