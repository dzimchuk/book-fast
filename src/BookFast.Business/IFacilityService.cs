using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Models;

namespace BookFast.Business
{
    public interface IFacilityService
    {
        Task<List<Facility>> ListByOwnerAsync(string owner);
        Task<Facility> FindAsync(Guid facilityId);
        Task CreateAsync(Facility facility);
        Task UpdateAsync(Facility facility);
        Task DeleteAsync(Guid facilityId);
    }
}