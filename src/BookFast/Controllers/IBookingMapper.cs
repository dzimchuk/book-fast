using BookFast.Contracts.Models;
using BookFast.ViewModels;

namespace BookFast.Controllers
{
    public interface IBookingMapper
    {
        BookingDetails MapFrom(CreateBookingViewModel viewModel);
    }
}