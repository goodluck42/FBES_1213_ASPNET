using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProductWebApiApplication.Models;

namespace ProductWebApiApplication.Controllers
{
    [ApiController]
    [Route("/api/v1/product/")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<List<Product>> All()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("range")]
        public async Task<List<Product>> Range(int from, int to)
        {
            return await _context.Products.Skip(from - 1).Take(to - from + 1).ToListAsync();
        }
    }
}