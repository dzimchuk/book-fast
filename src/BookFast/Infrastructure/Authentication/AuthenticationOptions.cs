using Microsoft.Extensions.Options;

namespace BookFast.Infrastructure.Authentication
{
    public class AuthenticationOptions
    {
        public string Instance { get; set; }
        public string TenantId { get; set; }

        public string Authority => $"{Instance}{TenantId}";

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public string PostLogoutRedirectUri { get; set; }

        public string ApiResource { get; set; }
    }
}