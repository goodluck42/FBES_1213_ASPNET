using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MyWebApplication.Service;

using System.Diagnostics;

namespace MyWebApplication.Pages
{
    public class CalculatorModel : PageModel
    {
        private readonly Calculator _calculator;

        [BindProperty(SupportsGet = true)]
        public string? Expr { get; set; }

        public CalculatorModel(Calculator calculator)
        {
            _calculator = calculator;
        }

        public void OnGet()
        {
            if (Expr != null)
            {
                ViewData["CalcResult"] = _calculator.Calc(Expr);
            }
        }
    }
}
