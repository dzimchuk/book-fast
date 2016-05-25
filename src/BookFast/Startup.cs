using BookFast.Contracts.Framework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using AuthenticationOptions = BookFast.Contracts.Security.AuthenticationOptions;

namespace BookFast
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            Configuration = builder.Build();

            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                (o, certificate, chain, errors) => true;
        }

        private IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var modules = new List<ICompositionModule>
                          {
                              new Composition.CompositionModule(),
                              new Proxy.Composition.CompositionModule()
                          };

            foreach (var module in modules)
            {
                module.AddServices(services, Configuration);
            }
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IOptions<AuthenticationOptions> authOptions)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true
            });


            var openIdOptions = new OpenIdConnectOptions
            {
                AutomaticChallenge = true,
                Authority = authOptions.Value.Authority,
                ClientId = authOptions.Value.ClientId,
                ClientSecret = authOptions.Value.ClientSecret,

                ResponseType = OpenIdConnectResponseTypes.CodeIdToken,

                SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme,
                PostLogoutRedirectUri = authOptions.Value.PostLogoutRedirectUri,

                Events = CreateOpenIdConnectEventHandlers(authOptions.Value)
            };
            app.UseOpenIdConnectAuthentication(openIdOptions);

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
                    return authenticationContext.AcquireTokenByAuthorizationCodeAsync(context.TokenEndpointRequest.Code,
                        new Uri(context.TokenEndpointRequest.RedirectUri, UriKind.RelativeOrAbsolute), clientCredential, authOptions.ApiResource);
                }
            };
        }
    }
}
