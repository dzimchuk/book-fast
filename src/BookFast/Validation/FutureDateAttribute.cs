﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BookFast.Validation
{
    public class FutureDateAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && ((DateTimeOffset)value).Date >= DateTime.Now.Date;
        }
    }
}