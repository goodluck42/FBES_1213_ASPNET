using Microsoft.AspNetCore.Mvc;

namespace AreaWebApplication.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
