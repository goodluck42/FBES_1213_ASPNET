using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PaginationWebApplication.Services;

namespace PaginationWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductHttpClient _productHttpClient;

        public ProductController(ProductHttpClient productHttpClient)
        {
            _productHttpClient = productHttpClient;
        }

        public async Task<IActionResult> List()
        {
            return View(await _productHttpClient.GetProductCountAsync());
        }

        public async Task<IActionResult> Index(int page)
        {
            if (page <= 0)
            {
                return View(await _productHttpClient.GetProductsAsync());
            }

            return View(await _productHttpClient.GetPageAsync(page));
        }
    }
}
