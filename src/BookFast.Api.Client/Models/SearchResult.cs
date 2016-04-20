// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace BookFast.Api.Client.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class SearchResult
    {
        /// <summary>
        /// Initializes a new instance of the SearchResult class.
        /// </summary>
        public SearchResult() { }

        /// <summary>
        /// Initializes a new instance of the SearchResult class.
        /// </summary>
        public SearchResult(double? score = default(double?), IDictionary<string, IList<string>> highlights = default(IDictionary<string, IList<string>>), IDictionary<string, object> document = default(IDictionary<string, object>))
        {
            Score = score;
            Highlights = highlights;
            Document = document;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Score")]
        public double? Score { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Highlights")]
        public IDictionary<string, IList<string>> Highlights { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Document")]
        public IDictionary<string, object> Document { get; set; }

    }
}