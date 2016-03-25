using System;
using System.Threading.Tasks;
using BookFast.Contracts.Models;

namespace BookFast.Contracts
{
    public interface IBookingService
    {
        Task BookAsync(Guid accommodationId, BookingDetails details);
    }
}