using ASP_DI_WebApplication.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_DI_WebApplication.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly ICounterService _counterService;
		private readonly IGuidService _guidService;

		public IndexModel(ILogger<IndexModel> logger, ICounterService counterService, IGuidService guidService)
		{
			_logger = logger;
			_counterService = counterService;
			_guidService = guidService;
		}

		public void OnGet()
		{
			ViewData["CurrentCounter"] = _counterService.ToString();
			ViewData["CurrentGuid"] = _guidService.Guid;
		}
	}
}