using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Business.Models;
using BookFast.Data.Queries;

namespace BookFast.Data
{
    internal class FacilityDataSource : IFacilityDataSource
    {
        private readonly BookFastContext context;

        public FacilityDataSource(BookFastContext context)
        {
            this.context = context;
        }

        public Task<List<Facility>> ListByOwnerAsync(string owner)
        {
            var query = new ListFacilitiesByOwnerQuery(owner);
            return query.ExecuteAsync(context);
        }
    }
}