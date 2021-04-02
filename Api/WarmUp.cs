using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorApp.Api
{
    /// <summary>
    /// Used purely to warm up the azure function instance
    /// </summary>
    public static class WarmUp
    {
        [FunctionName("WarmUp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log) => new OkObjectResult(true);
    }
}

