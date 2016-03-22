﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Configuration;

namespace BookFast.Search
{
    internal class BookFastIndex
    {
        private readonly ISearchServiceClient client;
        private readonly IConfiguration configuration;

        public BookFastIndex(ISearchServiceClient client, IConfiguration configuration)
        {
            this.client = client;
            this.configuration = configuration;
        }

        public async Task ProvisionAsync()
        {
            var indexName = configuration["search:indexName"];
            await DeleteIndexAsync(indexName);
            await CreateIndexAsync(indexName);
        }

        private async Task DeleteIndexAsync(string indexName)
        {
            if (await client.Indexes.ExistsAsync(indexName))
            {
                await client.Indexes.DeleteAsync(indexName);
            }
        }

        private Task CreateIndexAsync(string indexName)
        {
            var suggester = new Suggester
            {
                Name = "sg",
                SearchMode = SuggesterSearchMode.AnalyzingInfixMatching,
                SourceFields = new List<string> { "Name", "FacilityName" }
            };

            var definition = new Index
            {
                Name = indexName,
                Fields = new List<Field>
                                          {
                                              new Field("Id", DataType.String) { IsKey = true },
                                              new Field("FacilityId", DataType.String) { IsFilterable = true },
                                              new Field("Name", DataType.String) { IsSearchable = true },
                                              new Field("Description", DataType.String, AnalyzerName.EnMicrosoft) { IsSearchable = true },
                                              new Field("FacilityName", DataType.String) { IsSearchable = true },
                                              new Field("FacilityDescription", DataType.String, AnalyzerName.EnMicrosoft) { IsSearchable = true },
                                              new Field("Location", DataType.GeographyPoint) { IsFilterable = true }
                                          },
                Suggesters = new List<Suggester> { suggester }
            };

            return client.Indexes.CreateAsync(definition);
        }
    }
}