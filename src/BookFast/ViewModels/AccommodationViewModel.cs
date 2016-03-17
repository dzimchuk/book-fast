using System;
using System.ComponentModel.DataAnnotations;

namespace BookFast.ViewModels
{
    public class AccommodationViewModel
    {
        public Guid Id { get; set; }
        public Guid FacilityId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, 20)]
        public int RoomCount { get; set; }
    }
}