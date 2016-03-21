using System.Security.Claims;
using BookFast.Business;
using BookFast.Common.Security;

namespace BookFast.Infrastructure
{
    internal class SecurityContextProvider : ISecurityContext, ISecurityContextAcceptor
    {
        public ClaimsPrincipal Principal { get; set; }

        public string GetCurrentUser()
        {
            if (Principal == null)
                throw new System.Exception("Principal has not been initialized.");

            return Principal.GetUserName();
        }

        public string GetCurrentTenant()
        {
            if (Principal == null)
                throw new System.Exception("Principal has not been initialized.");

            var tenantClaim = Principal.FindFirst(BookFastClaimTypes.TenantId);
            if (tenantClaim == null)
                throw new System.Exception("No tenant claim found.");

            return tenantClaim.Value;
        }
    }
}