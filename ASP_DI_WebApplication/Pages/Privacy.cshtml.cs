using ASP_DI_WebApplication.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_DI_WebApplication.Pages
{
	public class PrivacyModel : PageModel
	{
		private readonly ILogger<PrivacyModel> _logger;
		private readonly ICounterService _counterService;

		public PrivacyModel(ILogger<PrivacyModel> logger, ICounterService counterService)
		{
			_logger = logger;
			_counterService = counterService;
		}

		public void OnGet()
		{
			ViewData["CurrentCounter"] = _counterService.Counter;
		}
	}
}