using BookFast.Business;
using BookFast.Contracts.Framework;
using BookFast.Contracts.Security;
using BookFast.Controllers;
using BookFast.Infrastructure;
using BookFast.Mappers;
using BookFast.Models;
using BookFast.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BookFast.Composition
{
    internal class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

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
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            var provider = new SecurityContextProvider();
            services.AddInstance<ISecurityContextAcceptor>(provider);
            services.AddInstance<ISecurityContext>(provider);
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddScoped<IFacilityMapper, FacilityMapper>();
            services.AddScoped<IAccommodationMapper, AccommodationMapper>();
        }
    }
}