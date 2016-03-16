using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Models;

namespace BookFast.Business
{
    public interface IAccommodationService
    {
        Task<ICollection<Accommodation>> ListAsync(Guid facilityId);
    }
}