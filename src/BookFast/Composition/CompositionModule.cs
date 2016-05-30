using BookFast.Contracts.Framework;
using BookFast.Contracts.Security;
using BookFast.Controllers;
using BookFast.Infrastructure;
using BookFast.Infrastructure.Authentication;
using BookFast.Mappers;
using BookFast.Proxy.RestClient;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BookFast.Composition
{
    internal class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication:AzureAd"));
            services.Configure<B2CAuthenticationOptions>(configuration.GetSection("Authentication:AzureAd:B2C"));
            services.Configure<B2CPolicies>(configuration.GetSection("Authentication:AzureAd:B2C:Policies"));

            services.AddScoped<SecurityContext>();
            services.AddScoped<IAccessTokenProvider, AccessTokenProvider>();

            services.AddMvc();

            RegisterAuthorizationPolicies(services);
            RegisterMappers(services);
        }

        private static void RegisterAuthorizationPolicies(IServiceCollection services)
        {
            services.AddAuthorization(
                options => options.AddPolicy("FacilityProviderOnly",
                    config => config.RequireRole(InteractorRole.FacilityProvider.ToString())));

            services.AddAuthorization(options => options.AddPolicy("Customer", 
                config => config.RequireClaim(BookFastClaimTypes.InteractorRole, new[] { InteractorRole.Customer.ToString() })));
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddScoped<IFacilityMapper, FacilityMapper>();
            services.AddScoped<IAccommodationMapper, AccommodationMapper>();
            services.AddScoped<IBookingMapper, BookingMapper>();
        }
    }
}