﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using BookFast.Contracts.Models;

namespace BookFast.Business.Services
{
    internal class AccommodationService : IAccommodationService
    {
        private readonly IAccommodationDataSource accommodationDataSource;
        private readonly IFacilityDataSource facilityDataSource;
        private readonly ISearchIndexer searchIndexer;

        public AccommodationService(IAccommodationDataSource accommodationDataSource, IFacilityDataSource facilityDataSource, ISearchIndexer searchIndexer)
        {
            this.accommodationDataSource = accommodationDataSource;
            this.facilityDataSource = facilityDataSource;
            this.searchIndexer = searchIndexer;
        }

        public async Task<List<Accommodation>> ListAsync(Guid facilityId)
        {
            if (!await facilityDataSource.ExistsAsync(facilityId))
                throw new FacilityNotFoundException(facilityId);

            return await accommodationDataSource.ListAsync(facilityId);
        }

        public async Task<Accommodation> FindAsync(Guid accommodationId)
        {
            var accommodation = await accommodationDataSource.FindAsync(accommodationId);
            if (accommodation == null)
                throw new AccommodationNotFoundException(accommodationId);

            return accommodation;
        }

        public async Task CreateAsync(Guid facilityId, AccommodationDetails details)
        {
            var facility = await facilityDataSource.FindAsync(facilityId);
            if (facility == null)
                throw new FacilityNotFoundException(facilityId);

            var accommodation = new Accommodation
                                {
                                    Id = Guid.NewGuid(),
                                    FacilityId = facilityId,
                                    Details = details
                                };

            await accommodationDataSource.CreateAsync(accommodation);

            facility.AccommodationCount++;
            await facilityDataSource.UpdateAsync(facility);

            await searchIndexer.IndexAccommodationAsync(accommodation, facility);
        }

        public async Task UpdateAsync(Guid accommodationId, AccommodationDetails details)
        {
            var accommodation = await accommodationDataSource.FindAsync(accommodationId);
            if (accommodation == null)
                throw new AccommodationNotFoundException(accommodationId);

            var facility = await facilityDataSource.FindAsync(accommodation.FacilityId);
            if (facility == null)
                throw new FacilityNotFoundException(accommodation.FacilityId);

            accommodation.Details = details;
            await accommodationDataSource.UpdateAsync(accommodation);

            await searchIndexer.IndexAccommodationAsync(accommodation, facility);
        }

        public async Task DeleteAsync(Guid accommodationId)
        {
            var accommodation = await accommodationDataSource.FindAsync(accommodationId);
            if (accommodation == null)
                throw new AccommodationNotFoundException(accommodationId);

            var facility = await facilityDataSource.FindAsync(accommodation.FacilityId);

            await accommodationDataSource.DeleteAsync(accommodationId);

            facility.AccommodationCount--;
            await facilityDataSource.UpdateAsync(facility);

            await searchIndexer.DeleteAccommodationIndexAsync(accommodationId);
        }
    }
}