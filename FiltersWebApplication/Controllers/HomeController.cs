using FiltersWebApplication.Filters;
using FiltersWebApplication.Models;
using FiltersWebApplication.Services;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;


namespace FiltersWebApplication.Controllers
{
	[MyResourceFilter]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly DummyService _dummyService;

		public HomeController(ILogger<HomeController> logger, DummyService dummyService)
		{
			_logger = logger;
			_dummyService = dummyService;
		}

		[MyActionFilter]
		[MyExceptionFilter("Error", "Home")]
		public IActionResult Index()
		{
			//_dummyService.DoSomeWork();

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}