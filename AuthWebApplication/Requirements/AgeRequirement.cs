using Microsoft.AspNetCore.Authorization;

namespace AuthWebApplication.Requirements
{
    public class AgeRequirement : IAuthorizationRequirement
    {
        public required int MaxAge { get; init; }
    }
}
