using AuthWebApplication.Models;

using System.Security.Claims;

namespace AuthWebApplication.Services
{
    public interface IUserClaimGenerator
    {
        ClaimsPrincipal GeneratePrincipal(User user);
    }
}
