﻿using System;
using System.ComponentModel.DataAnnotations;
using BookFast.ViewModels;

namespace BookFast.Validation
{
    public class DateRangeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var booking = value as CreateBookingViewModel;
            var now = DateTime.Now.Date;
            if (booking == null || booking.FromDate.Date < now || booking.ToDate.Date < now)
                return true;

            return booking.ToDate >= booking.FromDate;
        }
    }
}