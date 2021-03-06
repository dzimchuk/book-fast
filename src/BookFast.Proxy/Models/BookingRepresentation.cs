// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace BookFast.Proxy.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class BookingRepresentation
    {
        /// <summary>
        /// Initializes a new instance of the BookingRepresentation class.
        /// </summary>
        public BookingRepresentation() { }

        /// <summary>
        /// Initializes a new instance of the BookingRepresentation class.
        /// </summary>
        public BookingRepresentation(Guid? id = default(Guid?), Guid? accommodationId = default(Guid?), string accommodationName = default(string), Guid? facilityId = default(Guid?), string facilityName = default(string), string streetAddress = default(string), DateTime? fromDate = default(DateTime?), DateTime? toDate = default(DateTime?))
        {
            Id = id;
            AccommodationId = accommodationId;
            AccommodationName = accommodationName;
            FacilityId = facilityId;
            FacilityName = facilityName;
            StreetAddress = streetAddress;
            FromDate = fromDate;
            ToDate = toDate;
        }

        /// <summary>
        /// Booking ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Accommodation ID
        /// </summary>
        [JsonProperty(PropertyName = "accommodationId")]
        public Guid? AccommodationId { get; set; }

        /// <summary>
        /// Accommodation name
        /// </summary>
        [JsonProperty(PropertyName = "accommodationName")]
        public string AccommodationName { get; set; }

        /// <summary>
        /// Facility ID
        /// </summary>
        [JsonProperty(PropertyName = "facilityId")]
        public Guid? FacilityId { get; set; }

        /// <summary>
        /// Facility name
        /// </summary>
        [JsonProperty(PropertyName = "facilityName")]
        public string FacilityName { get; set; }

        /// <summary>
        /// Facility street address
        /// </summary>
        [JsonProperty(PropertyName = "streetAddress")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Booking start date
        /// </summary>
        [JsonProperty(PropertyName = "fromDate")]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Booking end date
        /// </summary>
        [JsonProperty(PropertyName = "toDate")]
        public DateTime? ToDate { get; set; }

    }
}
