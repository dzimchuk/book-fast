using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Common;
using System.Linq;
using BookFast.Business.Models;
using Microsoft.Data.Entity;

namespace BookFast.Data.Queries
{
    internal class ListFacilitiesByOwnerQuery : IQuery<BookFastContext, List<Facility>>
    {
        private readonly string owner;

        public ListFacilitiesByOwnerQuery(string owner)
        {
            this.owner = owner;
        }

        public Task<List<Facility>> ExecuteAsync(BookFastContext model)
        {
            return (from f in model.Facilities
                    where f.Owner.Equals(owner, StringComparison.OrdinalIgnoreCase)
                    select new Facility
                           {
                               Id = f.Id,
                               Name = f.Name,
                               Description = f.Description,
                               Owner = f.Owner,
                               StreetAddress = f.StreetAddress,
                               Latitude = f.Latitude,
                               Longitude = f.Longitude,
                               AccommodationCount = f.Accommodations.Count
                           }).ToListAsync();
        }
    }
}