using System;

namespace BookFast.Contracts.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public Guid AccommodationId { get; set; }
        public BookingDetails Details { get; set; } 
    }
}