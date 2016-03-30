using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Models;

namespace BookFast.Business.Data
{
    public interface IBookingDataSource
    {
        Task CreateAsync(Booking booking);
        Task<List<Booking>> ListAsync(string user);
    }
}