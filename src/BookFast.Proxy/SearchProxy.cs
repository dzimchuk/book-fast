using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts;
using BookFast.Contracts.Search;

namespace BookFast.Proxy
{
    internal class SearchProxy : ISearchService
    {
        public Task<IList<SearchResult>> SearchAsync(string searchText, int page)
        {
            throw new System.NotImplementedException();
        }
    }
}