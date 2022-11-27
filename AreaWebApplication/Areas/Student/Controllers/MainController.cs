using Microsoft.AspNetCore.Mvc;

namespace AreaWebApplication.Areas.Student.Controllers
{
	[Area("Student")]
	//[Route("Student/Main")]
	public class MainController : Controller
	{
		//[Route("Index/{id:int?}")]
		public IActionResult Index()
		{
			string str = "Hello world";

			return View
			(
				model: str
			);
		}

		//[Route("StudentInfo")]
		public IActionResult Info()
		{
			return View();
		}
	}
}
