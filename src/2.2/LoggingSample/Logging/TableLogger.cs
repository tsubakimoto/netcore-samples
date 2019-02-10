using LoggingSample.Logging.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace LoggingSample.Logging
{
    public class TableLogger : ILogger
    {
        private static object _lock = new Object();
        private readonly string _name;
        private readonly TableLoggerConfiguration _config;
        private readonly CloudTable _table;

        public TableLogger(string name, TableLoggerConfiguration config)
        {
            _name = name;
            _config = config;

            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(config.ConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference(config.TableName);
            _table.CreateIfNotExistsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            lock (_lock)
            {
                if (_config.EventId == 0 || _config.EventId == eventId.Id)
                {
                    var message = formatter(state, exception);
                    var entity = new TableLoggerEntity
                    {
                        LogLevel = logLevel.ToString(),
                        EventId = eventId.ToString(),
                        Name = _name,
                        Message = message
                    };
                    _table.ExecuteAsync(TableOperation.InsertOrReplace(entity)).ConfigureAwait(false).GetAwaiter().GetResult();
                    Console.WriteLine($"{logLevel.ToString()} - {eventId.Id} - {_name} - {message}");
                }
            }
        }
    }
}
