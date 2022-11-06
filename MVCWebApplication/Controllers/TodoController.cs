using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MVCWebApplication.Services;

using System.Net;

namespace MVCWebApplication.Controllers
{
	public class TodoController : Controller
	{
		private readonly IToDoList _toDoList;

			public TodoController(IToDoList toDoList)
		{
			_toDoList = toDoList;
		}

		public IActionResult Index()
		{
			ViewData["ToDoList"] = _toDoList.GetItems();

			return View();
		}

		[HttpPost]
		public IActionResult Add(string? description)
		{
			if (string.IsNullOrWhiteSpace(description))
			{
				return BadRequest();
			}

			_toDoList.AddItem(new()
			{
				Description = description
			});

			return Ok();
		}
		
		public IActionResult Edit()
		{
			return View();
		}

	}
}
