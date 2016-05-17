using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using BookFast.Contracts.Models;
using BookFast.Proxy.Models;

namespace BookFast.Proxy.Mappers
{
    internal class BookingMapper : IBookingMapper
    {
        private static readonly IMapper Mapper;

        static BookingMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
                {
                    configuration.CreateMap<BookingDetails, BookingData>()
                                 .ConvertUsing(details => new BookingData
                                                          {
                                                              FromDate = details.FromDate.UtcDateTime,
                                                              ToDate = details.ToDate.UtcDateTime
                                                          });
                configuration.CreateMap<BookingRepresentation, Booking>()
                             .ConvertUsing(representation => new Booking
                                                             {
                                                                 Id = Guid.Parse(representation.Id),
                                                                 AccommodationId = Guid.Parse(representation.AccommodationId),
                                                                 AccommodationName = representation.AccommodationName,
                                                                 FacilityId = Guid.Parse(representation.FacilityId),
                                                                 FacilityName = representation.FacilityName,
                                                                 StreetAddress = representation.StreetAddress,
                                                                 User = null,
                                                                 Details = new BookingDetails
                                                                           {
                                                                               FromDate = representation.FromDate.Value,
                                                                               ToDate = representation.ToDate.Value
                                                                           }
                                                             });
            });

            mapperConfiguration.AssertConfigurationIsValid();
            Mapper = mapperConfiguration.CreateMapper();
        }

        public BookingData MapFrom(BookingDetails details)
        {
            return Mapper.Map<BookingData>(details);
        }

        public Booking MapFrom(BookingRepresentation booking)
        {
            return Mapper.Map<Booking>(booking);
        }

        public List<Booking> MapFrom(IList<BookingRepresentation> bookings)
        {
            return Mapper.Map<List<Booking>>(bookings);
        }
    }
}