using System.Collections.Generic;
using BookFast.Business.Models;
using BookFast.ViewModels;
using System.Linq;
using BookFast.Controllers;

namespace BookFast.Mappers
{
    internal class AccommodationMapper : IAccommodationMapper
    {
        public AccommodationViewModel MapFrom(Accommodation accommodation)
        {
            return new AccommodationViewModel
                   {
                       Id = accommodation.Id,
                       FacilityId = accommodation.FacilityId,
                       Name = accommodation.Details.Name,
                       Description = accommodation.Details.Description,
                       RoomCount = accommodation.Details.RoomCount
                   };
        }

        public IEnumerable<AccommodationViewModel> MapFrom(IEnumerable<Accommodation> accommodations)
        {
            return accommodations.Select(MapFrom).ToList();
        }

        public AccommodationDetails MapFrom(AccommodationViewModel viewModel)
        {
            return new AccommodationDetails
                   {
                       Name = viewModel.Name,
                       Description = viewModel.Description,
                       RoomCount = viewModel.RoomCount
                   };
        }
    }
}