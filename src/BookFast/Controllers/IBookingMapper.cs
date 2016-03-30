using System.Collections.Generic;
using BookFast.Contracts.Models;
using BookFast.ViewModels;

namespace BookFast.Controllers
{
    public interface IBookingMapper
    {
        BookingDetails MapFrom(CreateBookingViewModel viewModel);
        IEnumerable<BookingViewModel> MapFrom(IEnumerable<Booking> bookings);
        BookingViewModel MapFrom(Booking booking);
    }
}