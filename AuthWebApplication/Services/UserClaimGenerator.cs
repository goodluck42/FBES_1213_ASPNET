using AuthWebApplication.Models;

using Microsoft.AspNetCore.Authentication.Cookies;

using System.Security.Claims;

namespace AuthWebApplication.Services
{
    public class UserClaimGenerator : IUserClaimGenerator
    {
        public ClaimsPrincipal GeneratePrincipal(User user)
        {
            // CBAC
            // Claim based access control
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString())
            };

            var identities = new List<ClaimsIdentity>()
            {
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)
            };

            return new ClaimsPrincipal(identities);
        }
    }
}
