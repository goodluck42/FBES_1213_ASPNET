using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MyWebApplication.Service;

using System.Diagnostics;

namespace MyWebApplication.Pages
{
	public class IndexModel : PageModel
	{
		//private readonly Calculator _calculator;
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger/*, Calculator calculator*/)
		{
			_logger = logger;
			//_calculator = calculator;
		}

		public void OnGet()
		{
			ViewData["DocumentTitle"] = "Index Page";
		}
	}
}