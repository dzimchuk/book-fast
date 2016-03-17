using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Business.Exceptions;
using BookFast.Business.Models;

namespace BookFast.Business.Services
{
    internal class FacilityService : IFacilityService
    {
        private readonly IFacilityDataSource dataSource;
        private readonly ISecurityContext securityContext;

        public FacilityService(IFacilityDataSource dataSource, ISecurityContext securityContext)
        {
            this.dataSource = dataSource;
            this.securityContext = securityContext;
        }

        public Task<List<Facility>> ListAsync()
        {
            return dataSource.ListByOwnerAsync(securityContext.GetCurrentTenant());
        }

        public async Task<Facility> FindAsync(Guid facilityId)
        {
            var facility = await dataSource.FindAsync(facilityId);
            if (facility == null)
                throw new FacilityNotFoundException(facilityId);

            return facility;
        }

        public Task CreateAsync(FacilityDetails details)
        {
            var facility = new Facility
                           {
                               Id = Guid.NewGuid(),
                               Details = details,
                               Location = new Location(),
                               Owner = securityContext.GetCurrentTenant()
                           };

            return dataSource.CreateAsync(facility);
        }

        public async Task UpdateAsync(Guid facilityId, FacilityDetails details)
        {
            var facility = await dataSource.FindAsync(facilityId);
            if (facility == null)
                throw new FacilityNotFoundException(facilityId);

            facility.Details = details;
            await dataSource.UpdateAsync(facility);
        }

        public async Task DeleteAsync(Guid facilityId)
        {
            if (!await dataSource.Exists(facilityId))
                throw new FacilityNotFoundException(facilityId);

            await dataSource.DeleteAsync(facilityId);
        }
    }
}