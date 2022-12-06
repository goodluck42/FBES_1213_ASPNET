using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace FiltersWebApplication.Filters
{
	public class MyExceptionFilterAttribute : Attribute, IAsyncExceptionFilter
	{
		private readonly string _actionName;
		private readonly string _controllerName;

		public MyExceptionFilterAttribute(string actionName, string controllerName = "Home")
		{
			_actionName = actionName;
			_controllerName = controllerName;
		}

		public async Task OnExceptionAsync(ExceptionContext context)
		{
			Console.WriteLine("[ExceptionFilter]");

			if (!context.ExceptionHandled && context.Exception is NotImplementedException exception)
			{
				context.Result = new RedirectToActionResult(_actionName, _controllerName, null);

				//context.HttpContext.Response.Redirect(this._redirectUrl);
			}
		}
	}
}
