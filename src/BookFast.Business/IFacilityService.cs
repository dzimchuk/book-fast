using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Models;

namespace BookFast.Business
{
    public interface IFacilityService
    {
        Task<List<Facility>> ListAsync();
        Task<Facility> FindAsync(Guid facilityId);
        Task CreateAsync(FacilityDetails details);
        Task UpdateAsync(Guid facilityId, FacilityDetails details);
        Task DeleteAsync(Guid facilityId);
    }
}