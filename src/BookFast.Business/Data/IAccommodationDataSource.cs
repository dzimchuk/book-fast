﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Models;

namespace BookFast.Business.Data
{
    public interface IAccommodationDataSource
    {
        Task<List<Accommodation>> ListAsync(Guid facilityId);
        Task<Accommodation> FindAsync(Guid accommodationId);
        Task CreateAsync(Accommodation accommodation);
        Task UpdateAsync(Accommodation accommodation);
        Task DeleteAsync(Guid accommodationId);
        Task<bool> ExistsAsync(Guid accommodationId);
    }
}