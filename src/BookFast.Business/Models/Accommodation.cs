using System;

namespace BookFast.Business.Models
{
    public class Accommodation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid FacilityId { get; set; }
        public int RoomCount { get; set; }
    }
}