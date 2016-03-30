﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BookFast.ViewModels
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Accommodation")]
        public string AccommodationName { get; set; }

        [Display(Name = "Facility")]
        public string FacilityName { get; set; }

        [Display(Name = "Street address")]
        public string StreetAddress { get; set; }

        [Display(Name = "Start date")]
        public DateTimeOffset FromDate { get; set; }

        [Display(Name = "End date")]
        public DateTimeOffset ToDate { get; set; } 
    }
}