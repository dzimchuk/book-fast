using System.Security.Claims;
using BookFast.Business;

namespace BookFast.Infrastructure
{
    internal class SecurityContextProvider : ISecurityContext, ISecurityContextAcceptor
    {
        private const string TenantIdClaimType = "book-fast-tenant-id";

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

            var tenantClaim = Principal.FindFirst(TenantIdClaimType);
            if (tenantClaim == null)
                throw new System.Exception("No tenant claim found.");

            return tenantClaim.Value;
        }
    }
}