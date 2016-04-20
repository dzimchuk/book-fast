using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts;
using BookFast.Contracts.Models;

namespace BookFast.Proxy
{
    internal class AccommodationProxy : IAccommodationService
    {
        public Task<List<Accommodation>> ListAsync(Guid facilityId)
        {
            throw new NotImplementedException();
        }

        public Task<Accommodation> FindAsync(Guid accommodationId)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Guid facilityId, AccommodationDetails details)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid accommodationId, AccommodationDetails details)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid accommodationId)
        {
            throw new NotImplementedException();
        }
    }
}