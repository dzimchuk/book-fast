using System.Collections.Generic;

namespace BookFast.Contracts.Search
{
    public class Document : Dictionary<string, object>
    {
        public Document(IDictionary<string, object> dictionary) : base(dictionary)
        {
        }
    }
}