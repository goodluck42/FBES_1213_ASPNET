using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using TagHelpersApplication.Models;

namespace TagHelpersApplication.Controllers
{
	public class Product
	{
		public int Id { get; set; }
		public string? Name { get; set; }
	}

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[ActionName("Index")]
		public IActionResult Index()
		{
			ViewData["Method"] = HttpContext.Request.Method;


			return View();
		}

		[HttpPost]
		[ActionName("Index")]
		public string GetData(string name, int id)
		{
			return $"name: {name} id: {id}";
		}

		public IActionResult Privacy()
		{
			var product = new Product()
			{
				Name = "Potato",
				Id = 1337
			};

			return View(product);
		}
		/*
		 * $.post("/Home/Delete", {
		 * id: @js
		 * })
		 */
		public void Delete(int id)
		{
			service.Delete(id);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}