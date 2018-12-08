using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareSample.Middlewares
{
    public class MyMiddleware
    {
        private readonly RequestDelegate next;

        public MyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await next(context);
        }
    }
}
