using AutoMapper;
using BookFast.Business.Data;
using BookFast.Common;
using BookFast.Data.Models;
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
            services.AddScoped<IAccommodationDataSource, AccommodationDataSource>();

            RegisterMappers(services);
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
                                                              {
                                                                  config.CreateMap<Business.Models.Facility, Facility>()
                                                                        .ForMember(dm => dm.Name, c => c.MapFrom(m => m.Details.Name))
                                                                        .ForMember(dm => dm.Description, c => c.MapFrom(m => m.Details.Description))
                                                                        .ForMember(dm => dm.StreetAddress, c => c.MapFrom(m => m.Details.StreetAddress))
                                                                        .ForMember(dm => dm.Latitude, c => c.MapFrom(m => m.Location.Latitude))
                                                                        .ForMember(dm => dm.Longitude, c => c.MapFrom(m => m.Location.Longitude))
                                                                        .ForMember(dm => dm.Accommodations, c => c.Ignore())
                                                                        .ReverseMap()
                                                                        .ConvertUsing(dm => new Business.Models.Facility
                                                                                            {
                                                                                                Id = dm.Id,
                                                                                                Owner = dm.Owner,
                                                                                                Details = new Business.Models.FacilityDetails
                                                                                                          {
                                                                                                              Name = dm.Name,
                                                                                                              Description = dm.Description,
                                                                                                              StreetAddress = dm.StreetAddress
                                                                                                          },
                                                                                                Location = new Business.Models.Location
                                                                                                           {
                                                                                                               Latitude = dm.Latitude,
                                                                                                               Longitude = dm.Longitude
                                                                                                           },
                                                                                                AccommodationCount = dm.AccommodationCount
                                                                                            });

                                                                  config.CreateMap<Business.Models.Accommodation, Accommodation>()
                                                                        .ForMember(dm => dm.Name, c => c.MapFrom(m => m.Details.Name))
                                                                        .ForMember(dm => dm.Description, c => c.MapFrom(m => m.Details.Description))
                                                                        .ForMember(dm => dm.RoomCount, c => c.MapFrom(m => m.Details.RoomCount))
                                                                        .ForMember(dm => dm.Facility, c => c.Ignore())
                                                                        .ReverseMap()
                                                                        .ConvertUsing(dm => new Business.Models.Accommodation
                                                                                            {
                                                                                                Id = dm.Id,
                                                                                                FacilityId = dm.FacilityId,
                                                                                                Details = new Business.Models.AccommodationDetails
                                                                                                          {
                                                                                                              Name = dm.Name,
                                                                                                              Description = dm.Description,
                                                                                                              RoomCount = dm.RoomCount
                                                                                                          }
                                                                                            });
                                                              });
            mapperConfiguration.AssertConfigurationIsValid();

            services.AddInstance(mapperConfiguration.CreateMapper());
        }
    }
}