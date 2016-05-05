using System.Collections.Generic;
using BookFast.Contracts.Models;
using BookFast.Proxy.Models;

namespace BookFast.Proxy
{
    public interface IAccommodationMapper
    {
        Accommodation MapFrom(AccommodationRepresentation accommodation);
        List<Accommodation> MapFrom(IList<AccommodationRepresentation> accommodations);
        AccommodationData MapFrom(AccommodationDetails details);
    }
}