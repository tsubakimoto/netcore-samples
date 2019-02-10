using Microsoft.Extensions.Logging;

namespace LoggingSample.Logging.Configuration
{
    public class TableLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
        public string ConnectionString { get; set; }
        public string TableName { get; set; }
    }
}
