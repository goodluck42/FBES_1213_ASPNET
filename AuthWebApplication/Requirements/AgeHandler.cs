using Microsoft.AspNetCore.Authorization;

using System.Security.Claims;

namespace AuthWebApplication.Requirements
{
    //public class AgeRequirement : IAuthorizationRequirement
    //{
    //    public int MaxAge { get; }

    //    public AgeRequirement2(int maxAge)
    //    {
    //        MaxAge = maxAge;
    //    }
    //}

    public class AgeHandler : AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            var birthdayClaim = context.User.FindFirst(ClaimTypes.DateOfBirth);

            if (birthdayClaim != null)
            {
                DateTime birthday = DateTime.Parse(birthdayClaim.Value);
                var diff = DateTime.Now.Year - birthday.Year;
                
                if (diff >= requirement.MaxAge)
                {
                    context.Succeed(requirement);

                    return Task.CompletedTask;
                }
            }

            context.Fail();

            return Task.CompletedTask;
        }
    }
}
