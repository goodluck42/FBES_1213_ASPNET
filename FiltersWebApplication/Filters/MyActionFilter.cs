using FiltersWebApplication.Controllers;

using Microsoft.AspNetCore.Mvc.Filters;


namespace FiltersWebApplication.Filters
{
	public class MyActionFilterAttribute : Attribute, IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			// Before action

			Console.WriteLine("[ActionFilter]");

			if (context.Controller is HomeController controller)
			{
				Console.WriteLine($"User-Agent: {context.HttpContext.Request.Headers.UserAgent}");
				Console.WriteLine($"ControllerName: {context.Controller.GetType()}");
			}

			await next();

			// After action
		}
	}
}
