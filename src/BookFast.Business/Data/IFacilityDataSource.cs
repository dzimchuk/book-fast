using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Models;

namespace BookFast.Business.Data
{
    public interface IFacilityDataSource
    {
        Task<List<Facility>> ListByOwnerAsync(string owner);
    }
}