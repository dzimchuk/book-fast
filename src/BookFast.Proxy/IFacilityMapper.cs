using System.Collections.Generic;
using BookFast.Contracts.Models;
using BookFast.Proxy.Models;

namespace BookFast.Proxy
{
    public interface IFacilityMapper
    {
        List<Facility> MapFrom(IList<FacilityRepresentation> facilities);
        Facility MapFrom(FacilityRepresentation facility);
        FacilityData MapFrom(FacilityDetails details);
    }
}