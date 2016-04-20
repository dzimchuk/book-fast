using System;
using System.Collections.Generic;
using BookFast.Contracts.Framework;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Authentication.OpenIdConnect;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using AuthenticationOptions = BookFast.Contracts.Security.AuthenticationOptions;

namespace BookFast
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        private IConfigurationRoot Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var modules = new List<ICompositionModule>
                          {
                              new Composition.CompositionModule()
                          };
#if DNX451
            modules.Add(new Proxy.Composition.CompositionModule());
#endif

            foreach (var module in modules)
            {
                module.AddServices(services, Configuration);
            }
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory, IOptions<AuthenticationOptions> authOptions)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());
            app.UseStaticFiles();

            app.UseCookieAuthentication(options => options.AutomaticAuthenticate = true);
            app.UseOpenIdConnectAuthentication(options =>
                                               {
                                                   options.AutomaticChallenge = true;
                                                   options.Authority = authOptions.Value.Authority;
                                                   options.ClientId = authOptions.Value.ClientId;
                                                   options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                                                   options.PostLogoutRedirectUri = authOptions.Value.PostLogoutRedirectUri;

                                                   options.Events = CreateOpenIdConnectEventHandlers(authOptions.Value);
                                               });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static IOpenIdConnectEvents CreateOpenIdConnectEventHandlers(AuthenticationOptions authOptions)
        {
            return new OpenIdConnectEvents
                   {
                       OnAuthorizationCodeReceived = context =>
                                                     {
                                                         var clientCredential = new ClientCredential(authOptions.ClientId, authOptions.ClientSecret);
                                                         var authenticationContext = new AuthenticationContext(authOptions.Authority);
                                                         return authenticationContext.AcquireTokenByAuthorizationCodeAsync(context.Code,
                                                             new Uri(context.RedirectUri, UriKind.RelativeOrAbsolute), clientCredential, authOptions.ApiResource);
                                                     }
                   };
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
