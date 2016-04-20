using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts;
using BookFast.Contracts.Models;

namespace BookFast.Proxy
{
    internal class FacilityProxy : IFacilityService
    {
        public Task<List<Facility>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Facility> FindAsync(Guid facilityId)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(FacilityDetails details)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid facilityId, FacilityDetails details)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid facilityId)
        {
            throw new NotImplementedException();
        }
    }
}