using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ActionFilterSample.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        ILogger _logger;
        public LoggingActionFilter(ILoggerFactory loggerFactory)
        {

            _logger = loggerFactory.CreateLogger<LoggingActionFilter>();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' executing");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' executed");
        }
    }
}
