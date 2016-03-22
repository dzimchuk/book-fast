using System.Collections.Generic;
using BookFast.Controllers;
using BookFast.ViewModels;
using System.Linq;
using BookFast.Contracts.Models;

namespace BookFast.Mappers
{
    internal class FacilityMapper : IFacilityMapper
    {
        public FacilityViewModel MapFrom(Facility facility)
        {
            return new FacilityViewModel
                   {
                       Id = facility.Id,
                       Name = facility.Details.Name,
                       Description = facility.Details.Description,
                       StreetAddress = facility.Details.StreetAddress,
                       Latitude = facility.Location.Latitude,
                       Longitude = facility.Location.Longitude,
                       AccommodationCount = facility.AccommodationCount
                   };
        }

        public IEnumerable<FacilityViewModel> MapFrom(IEnumerable<Facility> facilities)
        {
            return facilities.Select(MapFrom).ToList();
        }

        public FacilityDetails MapFrom(FacilityViewModel viewModel)
        {
            return new FacilityDetails
                   {
                       Name = viewModel.Name,
                       Description = viewModel.Description,
                       StreetAddress = viewModel.StreetAddress
                   };
        }
    }
}