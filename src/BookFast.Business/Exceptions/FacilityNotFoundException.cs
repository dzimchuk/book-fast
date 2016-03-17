using System;

namespace BookFast.Business.Exceptions
{
    public class FacilityNotFoundException : Exception
    {
        public Guid FacilityId { get; private set; }

        public FacilityNotFoundException(Guid facilityId)
        {
            FacilityId = facilityId;
        }
    }
}