using BookFast.Business;
using BookFast.Common;
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

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            var provider = new SecurityContextProvider();
            services.AddInstance<ISecurityContextAcceptor>(provider);
            services.AddInstance<ISecurityContext>(provider);

            RegisterMappers(services);
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddSingleton<IFacilityMapper, FacilityMapper>();
        }
    }
}