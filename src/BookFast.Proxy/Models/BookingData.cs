// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace BookFast.Proxy.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class BookingData
    {
        /// <summary>
        /// Initializes a new instance of the BookingData class.
        /// </summary>
        public BookingData() { }

        /// <summary>
        /// Initializes a new instance of the BookingData class.
        /// </summary>
        public BookingData(DateTime fromDate, DateTime toDate, Guid? accommodationId = default(Guid?))
        {
            AccommodationId = accommodationId;
            FromDate = fromDate;
            ToDate = toDate;
        }

        /// <summary>
        /// Accommodation ID
        /// </summary>
        [JsonProperty(PropertyName = "AccommodationId")]
        public Guid? AccommodationId { get; set; }

        /// <summary>
        /// Booking start date
        /// </summary>
        [JsonProperty(PropertyName = "FromDate")]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Booking end date
        /// </summary>
        [JsonProperty(PropertyName = "ToDate")]
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
