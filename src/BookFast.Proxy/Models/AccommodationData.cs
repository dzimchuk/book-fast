// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace BookFast.Proxy.Models
{
    using Newtonsoft.Json;
    using Microsoft.Rest;

    public partial class AccommodationData
    {
        /// <summary>
        /// Initializes a new instance of the AccommodationData class.
        /// </summary>
        public AccommodationData() { }

        /// <summary>
        /// Initializes a new instance of the AccommodationData class.
        /// </summary>
        public AccommodationData(string name, string description = default(string), int? roomCount = default(int?))
        {
            Name = name;
            Description = description;
            RoomCount = roomCount;
        }

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

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (this.Name != null)
            {
                if (this.Name.Length > 100)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Name", 100);
                }
                if (this.Name.Length < 3)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Name", 3);
                }
            }
            if (this.Description != null)
            {
                if (this.Description.Length > 1000)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Description", 1000);
                }
                if (this.Description.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Description", 0);
                }
            }
            if (this.RoomCount > 20)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "RoomCount", 20);
            }
            if (this.RoomCount < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "RoomCount", 0);
            }
        }
    }
}
