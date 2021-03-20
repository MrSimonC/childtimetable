using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BlazorApp.Api
{
    public static class GetEntries
    {
        [FunctionName("GetEntries")]
        public static async IAsyncEnumerable<TimetableItem> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post",
                Route = null)]HttpRequest req,
            [CosmosDB(
                databaseName: "childtimetabledb",
                collectionName: "activities",
                ConnectionStringSetting = "CosmosDBConnection")] DocumentClient client,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            Uri collectionUri = UriFactory.CreateDocumentCollectionUri("childtimetabledb", "activities");
            IDocumentQuery<TimetableItem> query = client.CreateDocumentQuery<TimetableItem>(collectionUri)
                //.Where(p => p.Description.Contains(searchterm))
                .AsDocumentQuery();

            while (query.HasMoreResults)
            {
                foreach (TimetableItem item in await query.ExecuteNextAsync())
                {

                    log.LogInformation(item.Name);
                    yield return item;
                }
            }
        }
    }
}