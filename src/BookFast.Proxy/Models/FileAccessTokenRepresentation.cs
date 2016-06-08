// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace BookFast.Proxy.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class FileAccessTokenRepresentation
    {
        /// <summary>
        /// Initializes a new instance of the FileAccessTokenRepresentation
        /// class.
        /// </summary>
        public FileAccessTokenRepresentation() { }

        /// <summary>
        /// Initializes a new instance of the FileAccessTokenRepresentation
        /// class.
        /// </summary>
        public FileAccessTokenRepresentation(string accessPermission = default(string), string url = default(string), string fileName = default(string))
        {
            AccessPermission = accessPermission;
            Url = url;
            FileName = fileName;
        }

        /// <summary>
        /// Possible values include: 'Read', 'Write', 'Delete'
        /// </summary>
        [JsonProperty(PropertyName = "AccessPermission")]
        public string AccessPermission { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Url")]
        public string Url { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "FileName")]
        public string FileName { get; set; }

    }
}
