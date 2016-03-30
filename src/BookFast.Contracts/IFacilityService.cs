using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Models;

namespace BookFast.Contracts
{
    public interface IFacilityService
    {
        Task<List<Facility>> ListAsync();
        Task<Facility> FindAsync(Guid facilityId);
        Task CreateAsync(FacilityDetails details);
        Task UpdateAsync(Guid facilityId, FacilityDetails details);
        Task DeleteAsync(Guid facilityId);
        Task CheckFacilityAsync(Guid facilityId);
        Task IncrementAccommodationCountAsync(Guid facilityId);
        Task DecrementAccommodationCountAsync(Guid facilityId);
    }
}