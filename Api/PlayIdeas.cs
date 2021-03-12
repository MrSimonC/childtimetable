using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Api
{
    public static class PlayIdeas
    {
        [FunctionName("PlayIdeas")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var result = new List<TimetableItem>{
                new TimetableItem { Time = "9am", Description = "Breakfast" },
                new TimetableItem { Time = "10am", Description = "Building Blocks" },
                new TimetableItem { Time = "11am", Description = "Walk outside" },
                new TimetableItem { Time = "12pm", Description = "Lunch" }
            };
            return new OkObjectResult(result);
        }
    }
}
