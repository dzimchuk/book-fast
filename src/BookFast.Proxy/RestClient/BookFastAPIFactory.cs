using System;
using System.Threading.Tasks;
using BookFast.Contracts.Security;
using Microsoft.Extensions.OptionsModel;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

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

            var authenticationResult = await authenticationContext.AcquireTokenSilentAsync(authOptions.ApiResource,
                clientCredential, UserIdentifier.AnyUser);

            return new BookFastAPI(new Uri(apiOptions.BaseUri, UriKind.Absolute), new TokenCredentials(authenticationResult.AccessToken));
        }
    }
}