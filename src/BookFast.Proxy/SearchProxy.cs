using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts;
using BookFast.Contracts.Search;

namespace BookFast.Proxy
{
    internal class SearchProxy : ISearchService
    {
        private readonly IBookFastAPIFactory restClientFactory;
        private readonly ISearchMapper mapper;

        public SearchProxy(IBookFastAPIFactory restClientFactory, ISearchMapper mapper)
        {
            this.restClientFactory = restClientFactory;
            this.mapper = mapper;
        }

        public async Task<IList<SearchResult>> SearchAsync(string searchText, int page)
        {
            var client = await restClientFactory.CreateAsync();
            var result = await client.SearchWithHttpMessagesAsync(searchText, page);

            return mapper.MapFrom(result.Body);
        }
    }
}