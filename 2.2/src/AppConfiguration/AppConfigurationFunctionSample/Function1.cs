using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AppConfigurationFunctionSample
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(Environment.GetEnvironmentVariable("ConnectionStrings:AppConfig"));
            var config = builder.Build();
            var message = config["AppConfigurationConsoleSample:Settings:Message"];
            message = message ?? req.Query["message"];

            return message != null
                ? (ActionResult)new OkObjectResult(message)
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
