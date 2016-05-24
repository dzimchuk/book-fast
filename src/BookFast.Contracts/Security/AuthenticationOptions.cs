using Microsoft.Extensions.Options;

namespace BookFast.Contracts.Security
{
    public class AuthenticationOptions : IOptions<AuthenticationOptions>
    {
        public string Instance { get; set; }
        public string TenantId { get; set; }

        public string Authority => $"{Instance}{TenantId}";

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public string PostLogoutRedirectUri { get; set; }

        public string ApiResource { get; set; }

        public AuthenticationOptions Value => this;
    }
}