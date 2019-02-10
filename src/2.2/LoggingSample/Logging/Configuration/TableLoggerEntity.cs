using Microsoft.WindowsAzure.Storage.Table;

namespace LoggingSample.Logging.Configuration
{
    public class TableLoggerEntity : TableEntity
    {
        [IgnoreProperty]
        public string LogLevel { get { return PartitionKey; } set { PartitionKey = value; } }
        [IgnoreProperty]
        public string EventId { get { return RowKey; } set { RowKey = value; } }

        public string Name { get; set; }
        public string Message { get; set; }
    }
}
