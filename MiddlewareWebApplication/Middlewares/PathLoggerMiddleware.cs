namespace MiddlewareWebApplication.Middlewares
{
	public class PathLoggerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly string _filePath;
		private readonly StreamWriter _streamWriter;

		public PathLoggerMiddleware(RequestDelegate requestDelegate, string filePath)
		{
			_next = requestDelegate;
			_filePath = filePath;
			_streamWriter = new StreamWriter(filePath)
			{
				AutoFlush = true
			};
		}

		public async Task Invoke(HttpContext httpContext)
		{
			_streamWriter.WriteLine(httpContext.Request.Path.ToString());

			await _next(httpContext);
		}
	}
}
