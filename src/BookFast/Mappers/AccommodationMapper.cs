using System.Collections.Generic;
using BookFast.ViewModels;
using AutoMapper;
using BookFast.Contracts.Models;
using BookFast.Controllers;

namespace BookFast.Mappers
{
    internal class AccommodationMapper : IAccommodationMapper
    {
        private static readonly IMapper Mapper;

        static AccommodationMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
                                                              {
                                                                  configuration.CreateMap<Accommodation, AccommodationViewModel>()
                                                                               .ForMember(vm => vm.Name, config => config.MapFrom(m => m.Details.Name))
                                                                               .ForMember(vm => vm.Description, config => config.MapFrom(m => m.Details.Description))
                                                                               .ForMember(vm => vm.RoomCount, config => config.MapFrom(m => m.Details.RoomCount));

                                                                  configuration.CreateMap<AccommodationDetails, AccommodationViewModel>();
                                                              });
            mapperConfiguration.AssertConfigurationIsValid();

            Mapper = mapperConfiguration.CreateMapper();
        }

        public AccommodationViewModel MapFrom(Accommodation accommodation)
        {
            return Mapper.Map<AccommodationViewModel>(accommodation);
        }

        public IEnumerable<AccommodationViewModel> MapFrom(IEnumerable<Accommodation> accommodations)
        {
            return Mapper.Map<IEnumerable<AccommodationViewModel>>(accommodations);
        }

        public AccommodationDetails MapFrom(AccommodationViewModel viewModel)
        {
            return Mapper.Map<AccommodationDetails>(viewModel);
        }
    }
}