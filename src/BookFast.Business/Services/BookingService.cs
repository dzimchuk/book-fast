using System;
using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Contracts;
using BookFast.Contracts.Models;

namespace BookFast.Business.Services
{
    internal class BookingService : IBookingService
    {
        private readonly IBookingDataSource dataSource;
        private readonly ISecurityContext securityContext;
        private readonly IAccommodationService accommodationService;

        public BookingService(IBookingDataSource dataSource, ISecurityContext securityContext, IAccommodationService accommodationService)
        {
            this.dataSource = dataSource;
            this.securityContext = securityContext;
            this.accommodationService = accommodationService;
        }

        public async Task BookAsync(Guid accommodationId, BookingDetails details)
        {
            await accommodationService.CheckAccommodationAsync(accommodationId);

            var booking = new Booking
                          {
                              Id = Guid.NewGuid(),
                              User = securityContext.GetCurrentUser(),
                              AccommodationId = accommodationId,
                              Details = details
                          };

            await dataSource.CreateAsync(booking);
        }
    }
}