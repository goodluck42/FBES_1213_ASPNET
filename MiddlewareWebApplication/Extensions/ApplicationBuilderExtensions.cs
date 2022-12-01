using MiddlewareWebApplication.Middlewares;

namespace MiddlewareWebApplication.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseUserIdentity(this IApplicationBuilder source)
		{
			return source.UseMiddleware<UserIdentityMiddleware>();
		}
		public static IApplicationBuilder UsePathLogger(this IApplicationBuilder source, string filePath)
		{
			return source.UseMiddleware<PathLoggerMiddleware>(filePath);
		}
	}
}
