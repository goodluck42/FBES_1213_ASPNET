using AuthWebApplication.Models;
using AuthWebApplication.Services;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;
using System.Security.Claims;
using System.Text;

namespace AuthWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> SignUp(string? returnUrl, [FromForm] User? user)
        {
            var userIdentity = HttpContext.User.Identity;

            if (userIdentity != null && userIdentity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            if (HttpContext.Request.Method == HttpMethods.Get)
            {
                return View();
            }

            if (user == null)
            {
                return BadRequest();
            }

            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();



                return Redirect(returnUrl ?? "/");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm] User? user)
        {
            var userIdentity = HttpContext.User.Identity;

            if (userIdentity != null && userIdentity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            if (HttpContext.Request.Method == HttpMethods.Get)
            {
                return View();
            }

            if (user == null)
            {
                return BadRequest();
            }

            try
            {

                var foundUser = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);

                if (foundUser == null)
                {
                    return Unauthorized();
                }

                var claim = new Claim(foundUser.Email!, foundUser.Password!);

                var claimsIdentity = new ClaimsIdentity(new Claim[1] { claim }, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest();
            }
        }


        [ActionName("SignOut")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var builder = new StringBuilder();
            var user = HttpContext.User.Identity;

            if (user != null && user.IsAuthenticated)
            {
                builder.Append("user authenticated");
            }
            else
            {
                builder.Append("user is not authenticated");
            }

            builder.Append("\nClaims: \n");


            var claims = HttpContext.User.Claims;

            foreach (var item in claims)
            {
                builder.Append($"Type: {item.Type} | Value: {item.Value} | ValueType: {item.ValueType} | Issuer: {item.Issuer}\n");
            }

            return View(model: builder.ToString());
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}