namespace MiddlewareWebApplication.Middlewares;

public class UserIdentityMiddleware
{
	private readonly RequestDelegate _next;

	public UserIdentityMiddleware(RequestDelegate requestDelegate)
	{
		_next = requestDelegate;
	}

	public async Task Invoke(HttpContext httpContext)
	{
		if (!httpContext.Request.Query.TryGetValue("userid", out var value))
		{
			httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
			await httpContext.Response.WriteAsJsonAsync(new
			{
				reason = "userid does not exist"
			});

			return;
		}

		// ...

		await _next(httpContext);
	}
}
