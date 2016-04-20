using BookFast.Business;
using BookFast.Contracts.Framework;
using BookFast.Contracts.Security;
using BookFast.Controllers;
using BookFast.Infrastructure;
using BookFast.Mappers;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BookFast.Composition
{
    internal class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc();

            RegisterAuthorizationPolicies(services);
            RegisterApplicationServices(services);
            RegisterMappers(services);

            services.AddInstance(configuration);
        }

        private static void RegisterAuthorizationPolicies(IServiceCollection services)
        {
            services.AddAuthorization(
                options => options.AddPolicy("FacilityProviderOnly", config => config.RequireClaim(BookFastClaimTypes.InteractorRole, InteractorRole.FacilityProvider.ToString())));
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            var provider = new SecurityContextProvider();
            services.AddInstance<ISecurityContextAcceptor>(provider);
            services.AddInstance<ISecurityContext>(provider);
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddScoped<IFacilityMapper, FacilityMapper>();
            services.AddScoped<IAccommodationMapper, AccommodationMapper>();
            services.AddScoped<IBookingMapper, BookingMapper>();
        }
    }
}