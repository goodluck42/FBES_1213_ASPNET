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
    [Authorize(Policy = "AdminOnly")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserClaimGenerator _userClaimGenerator;

        public HomeController(AppDbContext dbContext, IUserClaimGenerator userClaimGenerator)
        {
            _dbContext = dbContext;
            _userClaimGenerator = userClaimGenerator;
        }

        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
                // CBAC
                // Claim based access control

                await HttpContext.SignInAsync(_userClaimGenerator.GeneratePrincipal(foundUser));

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

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [Authorize(Policy = "MaxAge18")]
        public IActionResult SecretPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NoAccess()
        {
            return View();
        }
    }
}