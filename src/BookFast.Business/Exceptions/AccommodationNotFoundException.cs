using System;

namespace BookFast.Business.Exceptions
{
    public class AccommodationNotFoundException : Exception
    {
        public Guid AccommodationId { get; set; }

        public AccommodationNotFoundException(Guid accommodationId)
        {
            AccommodationId = accommodationId;
        }
    }
}