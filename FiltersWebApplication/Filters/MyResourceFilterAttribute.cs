using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace FiltersWebApplication.Filters
{
	public class MyResourceFilterAttribute : Attribute, IAsyncResourceFilter
	{
		public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
		{
			var userAgent = context.HttpContext.Request.Headers.UserAgent.ToString();

			if (userAgent.Contains("Edg"))
			{
				context.Result = new BadRequestResult();

				return;
			}

			await next();
		}
	}
}
