// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace BookFast.Proxy.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class AccommodationRepresentation
    {
        /// <summary>
        /// Initializes a new instance of the AccommodationRepresentation
        /// class.
        /// </summary>
        public AccommodationRepresentation() { }

        /// <summary>
        /// Initializes a new instance of the AccommodationRepresentation
        /// class.
        /// </summary>
        public AccommodationRepresentation(Guid? id = default(Guid?), Guid? facilityId = default(Guid?), string name = default(string), string description = default(string), int? roomCount = default(int?))
        {
            Id = id;
            FacilityId = facilityId;
            Name = name;
            Description = description;
            RoomCount = roomCount;
        }

        /// <summary>
        /// Accommodation ID
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Facility ID
        /// </summary>
        [JsonProperty(PropertyName = "FacilityId")]
        public Guid? FacilityId { get; set; }

        /// <summary>
        /// Accommodation name
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Accommodation description
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Number of rooms
        /// </summary>
        [JsonProperty(PropertyName = "RoomCount")]
        public int? RoomCount { get; set; }

    }
}
