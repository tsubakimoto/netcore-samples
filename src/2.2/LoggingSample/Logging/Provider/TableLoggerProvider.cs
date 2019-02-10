using LoggingSample.Logging.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingSample.Logging.Provider
{
    public class TableLoggerProvider : ILoggerProvider
    {
        private readonly TableLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, TableLogger> _loggers = new ConcurrentDictionary<string, TableLogger>();

        public TableLoggerProvider(TableLoggerConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new TableLogger(name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
