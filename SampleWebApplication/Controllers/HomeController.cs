using Microsoft.AspNetCore.Mvc;

using SampleWebApplication.Models;

using System.Diagnostics;

namespace SampleWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var result = new PrivacyViewModel
            {
                User = new User()
                {
                    Id = 1,
                    FirstName = "Niko"
                },
                Homework = null
            };

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}