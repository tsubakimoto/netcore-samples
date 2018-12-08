using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IdentityMiddlewareSample.Middlewares
{
    public class EmailMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<EmailMiddleware> logger;
        private readonly UserManager<IdentityUser> userManager;

        public EmailMiddleware(RequestDelegate next, ILogger<EmailMiddleware> logger, IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            this.next = next;
            this.logger = logger;
            this.userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/Identity/Account/Login"
                || context.Request.Path == "/Identity/Account/Logout")
            {
                logger.LogInformation("Do login or logout.");
                await next(context);
                return;
            }

            if (context.User == null)
            {
                logger.LogInformation("1: User not logged in.");
                context.Response.Redirect("/Identity/Account/Login");
                return;
            }

            var user = await userManager.GetUserAsync(context.User);
            if (user == null)
            {
                logger.LogInformation("2: User not logged in.");
                context.Response.Redirect("/Identity/Account/Login");
                return;
            }

            if (user.Email.StartsWith("hoge"))
            {
                await context.Response.WriteAsync("3: Are you hoge?");
                return;
            }

            await next(context);
        }
    }
}
