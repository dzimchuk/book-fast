using System.Collections.Generic;
using BookFast.Business.Models;
using BookFast.ViewModels;

namespace BookFast.Controllers
{
    public interface IAccommodationMapper
    {
        AccommodationViewModel MapFrom(Accommodation accommodation);
        IEnumerable<AccommodationViewModel> MapFrom(IEnumerable<Accommodation> accommodations);
        AccommodationDetails MapFrom(AccommodationViewModel viewModel);
    }
}