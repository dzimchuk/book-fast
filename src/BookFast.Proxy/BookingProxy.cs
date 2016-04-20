using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts;
using BookFast.Contracts.Models;

namespace BookFast.Proxy
{
    internal class BookingProxy : IBookingService
    {
        public Task BookAsync(Guid accommodationId, BookingDetails details)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> ListPendingAsync()
        {
            throw new NotImplementedException();
        }

        public Task CancelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> FindAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}