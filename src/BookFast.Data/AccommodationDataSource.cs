using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookFast.Business.Data;
using BookFast.Data.Commands;
using BookFast.Data.Models;
using BookFast.Data.Queries;
using Accommodation = BookFast.Business.Models.Accommodation;

namespace BookFast.Data
{
    internal class AccommodationDataSource : IAccommodationDataSource
    {
        private readonly BookFastContext context;
        private readonly IMapper mapper;

        public AccommodationDataSource(BookFastContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<List<Accommodation>> ListAsync(Guid facilityId)
        {
            var query = new ListAccommodationsQuery(facilityId, mapper);
            return query.ExecuteAsync(context);
        }

        public Task<Accommodation> FindAsync(Guid accommodationId)
        {
            var query = new FindAccommodationQuery(accommodationId, mapper);
            return query.ExecuteAsync(context);
        }

        public Task CreateAsync(Accommodation accommodation)
        {
            var command = new CreateAccommodationCommand(accommodation, mapper);
            return command.ApplyAsync(context);
        }

        public Task UpdateAsync(Accommodation accommodation)
        {
            var command = new UpdateAccommodationCommand(accommodation);
            return command.ApplyAsync(context);
        }

        public Task DeleteAsync(Guid accommodationId)
        {
            var command = new DeleteAccommodationCommand(accommodationId);
            return command.ApplyAsync(context);
        }
    }
}