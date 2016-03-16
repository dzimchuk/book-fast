using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Business.Models;

namespace BookFast.Business.Services
{
    internal class FacilityService : IFacilityService
    {
        private readonly IFacilityDataSource dataSource;

        public FacilityService(IFacilityDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public Task<List<Facility>> ListByOwnerAsync(string owner)
        {
            return dataSource.ListByOwnerAsync(owner);
        }

        public Task<Facility> FindAsync(Guid facilityId)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Facility facility)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Facility facility)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid facilityId)
        {
            throw new NotImplementedException();
        }
    }
}