﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using BookFast.Contracts.Models;

namespace BookFast.Proxy
{
    internal class AccommodationProxy : IAccommodationService
    {
        private readonly IBookFastAPIFactory restClientFactory;
        private readonly IAccommodationMapper mapper;

        public AccommodationProxy(IBookFastAPIFactory restClientFactory, IAccommodationMapper mapper)
        {
            this.restClientFactory = restClientFactory;
            this.mapper = mapper;
        }

        public async Task<List<Accommodation>> ListAsync(Guid facilityId)
        {
            var client = await restClientFactory.CreateAsync();
            var result = await client.ListAccommodationsWithHttpMessagesAsync(facilityId.ToString());

            if (result.Response.StatusCode == HttpStatusCode.NotFound)
                throw new FacilityNotFoundException(facilityId);

            return mapper.MapFrom(result.Body);
        }

        public async Task<Accommodation> FindAsync(Guid accommodationId)
        {
            var client = await restClientFactory.CreateAsync();
            var result = await client.FindAccommodationWithHttpMessagesAsync(accommodationId.ToString());

            if (result.Response.StatusCode == HttpStatusCode.NotFound)
                throw new AccommodationNotFoundException(accommodationId);

            return mapper.MapFrom(result.Body);
        }

        public async Task CreateAsync(Guid facilityId, AccommodationDetails details)
        {
            var client = await restClientFactory.CreateAsync();
            var result = await client.CreateAccommodationWithHttpMessagesAsync(facilityId.ToString(), mapper.MapFrom(details));

            if (result.Response.StatusCode == HttpStatusCode.NotFound)
                throw new FacilityNotFoundException(facilityId);
        }

        public async Task UpdateAsync(Guid accommodationId, AccommodationDetails details)
        {
            var client = await restClientFactory.CreateAsync();
            var result = await client.UpdateAccommodationWithHttpMessagesAsync(accommodationId.ToString(), mapper.MapFrom(details));

            if (result.Response.StatusCode == HttpStatusCode.NotFound)
                throw new AccommodationNotFoundException(accommodationId);
        }

        public async Task DeleteAsync(Guid accommodationId)
        {
            var client = await restClientFactory.CreateAsync();
            var result = await client.DeleteAccommodationWithHttpMessagesAsync(accommodationId.ToString());

            if (result.Response.StatusCode == HttpStatusCode.NotFound)
                throw new AccommodationNotFoundException(accommodationId);
        }
    }
}