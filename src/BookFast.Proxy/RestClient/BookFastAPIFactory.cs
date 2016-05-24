using System;
using System.Threading.Tasks;
using BookFast.Contracts.Security;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Extensions.Options;

namespace BookFast.Proxy.RestClient
{
    internal class BookFastAPIFactory : IBookFastAPIFactory
    {
        private readonly AuthenticationOptions authOptions;
        private readonly ApiOptions apiOptions;
        
        public BookFastAPIFactory(IOptions<AuthenticationOptions> authOptions, IOptions<ApiOptions> apiOptions)
        {
            this.authOptions = authOptions.Value;
            this.apiOptions = apiOptions.Value;
        }

        public async Task<IBookFastAPI> CreateAsync()
        {
            var clientCredential = new ClientCredential(authOptions.ClientId, authOptions.ClientSecret);
            var authenticationContext = new AuthenticationContext(authOptions.Authority);

            try
            {
                var authenticationResult = await authenticationContext.AcquireTokenSilentAsync(authOptions.ApiResource,
                    clientCredential, UserIdentifier.AnyUser);

                return new BookFastAPI(new Uri(apiOptions.BaseUrl, UriKind.Absolute), new TokenCredentials(authenticationResult.AccessToken));
            }
            catch (AdalSilentTokenAcquisitionException)
            {
                return new BookFastAPI(new Uri(apiOptions.BaseUrl, UriKind.Absolute), new EmptyCredentials());
            }
        }
    }
}