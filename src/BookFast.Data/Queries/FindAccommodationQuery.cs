using System;
using System.Threading.Tasks;
using AutoMapper;
using BookFast.Common;
using BookFast.Data.Models;
using Microsoft.Data.Entity;
using Accommodation = BookFast.Business.Models.Accommodation;

namespace BookFast.Data.Queries
{
    internal class FindAccommodationQuery : IQuery<BookFastContext, Accommodation>
    {
        private readonly Guid accommodationId;
        private readonly IMapper mapper;

        public FindAccommodationQuery(Guid accommodationId, IMapper mapper)
        {
            this.accommodationId = accommodationId;
            this.mapper = mapper;
        }

        public async Task<Accommodation> ExecuteAsync(BookFastContext model)
        {
            var accommodation = await model.Accommodations.FirstOrDefaultAsync(a => a.Id == accommodationId);
            return accommodation != null ? mapper.Map<Accommodation>(accommodation) : null;
        }
    }
}