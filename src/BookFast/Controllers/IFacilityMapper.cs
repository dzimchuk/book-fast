using System.Collections.Generic;
using BookFast.ViewModels;

namespace BookFast.Controllers
{
    public interface IFacilityMapper
    {
        FacilityViewModel MapFrom(Business.Models.Facility facility);
        IEnumerable<FacilityViewModel> MapFrom(IEnumerable<Business.Models.Facility> facilities);
        Business.Models.FacilityDetails MapFrom(FacilityViewModel viewModel);
    }
}