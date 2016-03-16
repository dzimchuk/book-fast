using BookFast.Business.Data;
using BookFast.Common;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BookFast.Data.Composition
{
    public class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            var efBuilder = new EntityFrameworkServicesBuilder(services);
            efBuilder.AddDbContext<BookFastContext>(options => options.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddScoped<IFacilityDataSource, FacilityDataSource>();
        }
    }
}