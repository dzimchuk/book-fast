using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookFast.Common;
using BookFast.Data.Models;
using Accommodation = BookFast.Business.Models.Accommodation;
using System.Linq;
using BookFast.Common.Framework;
using Microsoft.Data.Entity;

namespace BookFast.Data.Queries
{
    internal class ListAccommodationsQuery : IQuery<BookFastContext, List<Accommodation>>
    {
        private readonly Guid facilityId;
        private readonly IMapper mapper;

        public ListAccommodationsQuery(Guid facilityId, IMapper mapper)
        {
            this.facilityId = facilityId;
            this.mapper = mapper;
        }

        public async Task<List<Accommodation>> ExecuteAsync(BookFastContext model)
        {
            var accommodations = await model.Accommodations.Where(a => a.FacilityId == facilityId).ToListAsync();
            return mapper.Map<List<Accommodation>>(accommodations);
        }
    }
}