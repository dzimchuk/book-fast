using BookFast.Contracts;
using BookFast.Contracts.Framework;
using BookFast.Proxy.Mappers;
using BookFast.Proxy.RestClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookFast.Proxy.Composition
{
    public class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFacilityService, FacilityProxy>();
            services.AddScoped<IAccommodationService, AccommodationProxy>();
            services.AddScoped<IBookingService, BookingProxy>();
            services.AddScoped<ISearchService, SearchProxy>();

            services.Configure<ApiOptions>(configuration.GetSection("BookFastApi"));
            services.AddScoped<IBookFastAPIFactory, BookFastAPIFactory>();

            services.AddScoped<IFacilityMapper, FacilityMapper>();
            services.AddScoped<IAccommodationMapper, AccommodationMapper>();
            services.AddScoped<IBookingMapper, BookingMapper>();
            services.AddScoped<ISearchMapper, SearchMapper>();
            services.AddScoped<IFileAccessMapper, FileAccessMapper>();
        }
    }
}