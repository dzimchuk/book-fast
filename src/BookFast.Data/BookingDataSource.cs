using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Data.Commands;
using BookFast.Data.Models;
using Booking = BookFast.Contracts.Models.Booking;

namespace BookFast.Data
{
    internal class BookingDataSource : IBookingDataSource
    {
        private readonly BookFastContext context;
        private readonly IBookingMapper mapper;

        public BookingDataSource(BookFastContext context, IBookingMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task CreateAsync(Booking booking)
        {
            var command = new CreateBookingCommand(booking, mapper);
            return command.ApplyAsync(context);
        }
    }
}