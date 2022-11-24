using Microsoft.AspNetCore.Mvc;

namespace TagHelpersApplication.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
