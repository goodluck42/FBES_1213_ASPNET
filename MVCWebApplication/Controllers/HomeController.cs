using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Models;
using MVCWebApplication.Services;

using System.Diagnostics;

namespace MVCWebApplication.Controllers
{
	public class HomeController : Controller
	{
		public HomeController()
		{
		}

		[HttpGet]
		[HttpPost]
		public IActionResult Index()
		{

			ViewData["MyDescription"] = "Hello Vadim";

			//bool error = true;

			//if (error)
			//{
			//	return NotFound();
			//}

			return View();
		}

		public IActionResult Privacy()
		{
			ViewData["MyDescription"] = "Hello Seymur";

			return View("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}