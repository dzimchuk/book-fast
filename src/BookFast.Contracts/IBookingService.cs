﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Models;

namespace BookFast.Contracts
{
    public interface IBookingService
    {
        Task BookAsync(Guid accommodationId, BookingDetails details);
        Task<List<Booking>> ListAsync();
    }
}