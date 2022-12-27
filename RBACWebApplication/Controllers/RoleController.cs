using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RBACWebApplication.Models;

using System.Data;
using System.Text;

namespace RBACWebApplication.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Role? role)
        {
            if (HttpContext.Request.Method == HttpMethods.Get)
            {
                return View();
            }

            if (role == null)
            {
                return RedirectToAction( "Error");
            }

            var result = await _roleManager.CreateAsync(new IdentityRole
            {
                Name = role.Rolename
            });

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> List()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> AddTo([FromForm] UserRole? userRole)
        {
            if (HttpContext.Request.Method == HttpMethods.Get)
            {
                return View();
            }

            if (userRole == null)
            {
                return RedirectToAction( "Error");
            }

            var identityUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == userRole.Email);

            if (identityUser == null)
            {
                return RedirectToAction("Error");
            }

            var result = await _userManager.AddToRoleAsync(identityUser, userRole.Rolename!);


            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }


            return RedirectToAction("Error");
        }
    }
}
