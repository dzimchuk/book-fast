using System.Collections.Generic;
using BookFast.Contracts.Models;
using BookFast.Proxy.Models;

namespace BookFast.Proxy
{
    public interface IBookingMapper
    {
        BookingData MapFrom(BookingDetails details);
        Booking MapFrom(BookingRepresentation booking);
        List<Booking> MapFrom(IList<BookingRepresentation> bookings);
    }
}