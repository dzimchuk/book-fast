using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Models;

namespace BookFast.Contracts
{
    public interface IAccommodationService
    {
        Task<List<Accommodation>> ListAsync(Guid facilityId);
        Task<Accommodation> FindAsync(Guid accommodationId);
        Task CreateAsync(Guid facilityId, AccommodationDetails details);
        Task UpdateAsync(Guid accommodationId, AccommodationDetails details);
        Task DeleteAsync(Guid accommodationId);
    }
}