using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MiddlewareSample.Services;
using System.Threading.Tasks;

namespace MiddlewareSample.Middlewares
{
    public class MyMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<MyMiddleware> logger;

        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IMyService myService)
        {
            string message = myService.Say("tsubakimoto");
            logger.LogInformation("message is '{message}'", message);
            await next(context);
        }
    }
}
