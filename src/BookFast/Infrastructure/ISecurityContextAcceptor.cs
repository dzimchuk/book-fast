using System.Security.Claims;

namespace BookFast.Infrastructure
{
    internal interface ISecurityContextAcceptor
    {
        ClaimsPrincipal Principal { set; }
    }
}