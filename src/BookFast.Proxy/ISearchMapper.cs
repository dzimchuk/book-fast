using System.Collections.Generic;
using BookFast.Proxy.Models;

namespace BookFast.Proxy
{
    public interface ISearchMapper
    {
        IList<Contracts.Search.SearchResult> MapFrom(IList<SearchResult> results);
    }
}