// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace BookFast.Api.Client.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class BookingData
    {
        /// <summary>
        /// Initializes a new instance of the BookingData class.
        /// </summary>
        public BookingData() { }

        /// <summary>
        /// Initializes a new instance of the BookingData class.
        /// </summary>
        public BookingData(DateTime fromDate, DateTime toDate, string accommodationId = default(string))
        {
            AccommodationId = accommodationId;
            FromDate = fromDate;
            ToDate = toDate;
        }

        /// <summary>
        /// Accommodation ID
        /// </summary>
        [JsonProperty(PropertyName = "AccommodationId")]
        public string AccommodationId { get; set; }

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
