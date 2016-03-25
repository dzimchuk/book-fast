using AutoMapper;
using BookFast.Contracts.Models;
using BookFast.Controllers;
using BookFast.ViewModels;

namespace BookFast.Mappers
{
    internal class BookingMapper : IBookingMapper
    {
        private static readonly IMapper Mapper;

        static BookingMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
                                                              {
                                                                  configuration.CreateMap<CreateBookingViewModel, BookingDetails>();
                                                              });
            mapperConfiguration.AssertConfigurationIsValid();

            Mapper = mapperConfiguration.CreateMapper();
        }

        public BookingDetails MapFrom(CreateBookingViewModel viewModel)
        {
            return Mapper.Map<BookingDetails>(viewModel);
        }
    }
}