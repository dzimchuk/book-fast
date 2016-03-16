using AutoMapper;
using BookFast.Common;
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

            RegisterMappers(services);
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
                                                              {
                                                                  config.CreateMap<Business.Models.Facility, ViewModels.FacilityViewModel>();
                                                              });

            services.AddInstance(mapperConfiguration.CreateMapper());
        }
    }
}