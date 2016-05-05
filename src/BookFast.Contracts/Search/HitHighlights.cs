﻿using System.Collections.Generic;

namespace BookFast.Contracts.Search
{
    public class HitHighlights : Dictionary<string, IList<string>>
    {
        public HitHighlights(IDictionary<string, IList<string>> dictionary) : base(dictionary)
        {
        }
    }
}