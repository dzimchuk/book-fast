using System.Collections.Generic;
using BookFast.Contracts.Models;
using BookFast.ViewModels;

namespace BookFast.Controllers
{
    public interface IFacilityMapper
    {
        FacilityViewModel MapFrom(Facility facility);
        IEnumerable<FacilityViewModel> MapFrom(IEnumerable<Facility> facilities);
        FacilityDetails MapFrom(FacilityViewModel viewModel);
    }
}