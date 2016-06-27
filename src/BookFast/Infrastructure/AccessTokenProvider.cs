﻿using BookFast.Infrastructure.Authentication;
using BookFast.Proxy.RestClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BookFast.Infrastructure
{
    internal class AccessTokenProvider : IAccessTokenProvider
    {
        private readonly AuthenticationOptions authOptions;
        private readonly B2CAuthenticationOptions b2cAuthOptions;
        private readonly IAuthorizationService authorizationService;
        private readonly SecurityContext securityContext;

        private const string ObjectId = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        public AccessTokenProvider(IOptions<AuthenticationOptions> authOptions, IOptions<B2CAuthenticationOptions> b2cAuthOptions, 
            IAuthorizationService authorizationService, SecurityContext securityContext)
        {
            this.authOptions = authOptions.Value;
            this.b2cAuthOptions = b2cAuthOptions.Value;
            this.authorizationService = authorizationService;
            this.securityContext = securityContext;
        }

        public async Task<string> AcquireTokenAsync()
        {
            return await authorizationService.AuthorizeAsync(securityContext.Principal, "FacilityProviderOnly") ?
                await OrganizationalAuthentication.AcquireAccessTokenAsync(authOptions, GetUserId()) : await B2CAuthentication.AcquireAccessTokenAsync(b2cAuthOptions);
        }

        private string GetUserId()
        {
            if (securityContext.Principal == null)
                return null;

            return securityContext.Principal.FindFirst(ObjectId)?.Value;
        }
    }
}
