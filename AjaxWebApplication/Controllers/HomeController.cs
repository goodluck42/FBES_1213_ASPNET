using AjaxWebApplication.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace AjaxWebApplication.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private static readonly List<Car> s_cars = new List<Car>()
		{
			new Car()
			{
				Id = 1,
				Model = "Nissan",
				Price = 29000,
				Speed = 6
			},
			new Car()
			{
				Id = 2,
				Model = "Mercedes",
				Price = 10000,
				Speed = 5
			},
			new Car()
			{
				Id = 3,
				Model = "Lexus",
				Price = 100000,
				Speed = 7
			},
		};

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View(model: s_cars);
		}
		// Home/Add
		[HttpPost]
		public IActionResult Add([FromBody] Car? car)
		{
			if (car == null)
			{
				return BadRequest();
			}

			try
			{
				car.Id = s_cars.Last().Id + 1;
				s_cars.Add(car);

				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		// /Home/Remove
		[HttpPost]
		// { "id": 1 }
		public IActionResult Remove([FromBody] Car? car)
		{
			if (car == null)
			{
				return BadRequest();
			}

			var target = s_cars.Find(c => c.Id == car.Id);

			if (target != null)
			{
				s_cars.Remove(target);

				return Ok();
			}

			return BadRequest();
		}
		
		// Home/Update
		[HttpPost]
		public IActionResult Update([FromBody] Car? car)
		{
			if (car == null)
			{
				return BadRequest();
			}

			var target = s_cars.Find(c => c.Id == car.Id);

			if (target != null)
			{
				target.Update(car);

				return Ok();
			}

			return BadRequest();
		}

		[HttpGet]
		[ActionName("Add")]
		public IActionResult Add()
		{
			return View();
		}

		[HttpGet]
		// /Home/GetCars
		public IActionResult GetCars()
		{
			return Json(s_cars);
		}

		[HttpGet]
		public IActionResult CarList()
		{
			return View();
		}

		public IActionResult UpdateCar()
		{
			return View();
		}
	}
}