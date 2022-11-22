using Microsoft.AspNetCore.Mvc;

namespace RoutingApplication.Controllers
{
	// localhost:1234/route/main
	[Route("user")]
	// [Route("/user/{action=main}/{id:int?}")]
	public class RouteController : Controller
	{
		[Route("main")]
		public string Index()
		{
			return $"user/main";
		}

		[Route("add/{name?}/{age:int?}")]
		public string Create(string? name, int? age)
		{
			return $"user/add name={name} age={age}";
		}
		
		[Route("get/{id:int?}")]
		public string Get(int? id)
		{
			return $"user/get id={id}";
		}
	}
}
