using System.Security.Claims;

namespace BookFast.Infrastructure
{
    internal class SecurityContext
    {
        public ClaimsPrincipal Principal { get; set; }
    }
}
