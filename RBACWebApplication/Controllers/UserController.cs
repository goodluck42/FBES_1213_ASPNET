using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using RBACWebApplication.Models;

namespace RBACWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IPasswordHasher<IdentityUser> passwordHasher)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _userManager.GetUserAsync(HttpContext.User));
        }


        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm] User? user)
        {
            if (HttpContext.Request.Method == HttpMethods.Get)
            {
                return View();
            }

            if (user == null)
            {
                return RedirectToAction("Error");
            }

            if (user.Password == null)
            {
                return RedirectToAction("Error");
            }

            var result = await _userManager.CreateAsync(new IdentityUser
            {
                Email = user.Email,
                UserName = user.UserName
            }, user.Password);


            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm] User? user)
        {
            if (HttpContext.Request.Method == HttpMethods.Get)
            {
                return View();
            }

            if (user == null)
            {
                return RedirectToAction("Error");
            }

            if (user.Password == null)
            {
                return RedirectToAction("Error");
            }

            
            var identityUser = await _userManager.FindByEmailAsync(user.Email!);

            if (identityUser == null)
            {
                return RedirectToAction("Error");
            }

            var result = await _signInManager.PasswordSignInAsync(identityUser, user.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
