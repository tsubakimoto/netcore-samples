﻿using LoggingSample.Logging.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingSample.Logging
{
    public class ColoredConsoleLogger : ILogger
    {
        private static object _lock = new Object();
        private readonly string _name;
        private readonly ColoredConsoleLoggerConfiguration _config;

        public ColoredConsoleLogger(string name, ColoredConsoleLoggerConfiguration config)
        {
            _name = name;
            _config = config;
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
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = _config.Color;
                    Console.WriteLine($"{logLevel.ToString()} - {eventId.Id} - {_name} - {formatter(state, exception)}");
                    Console.ForegroundColor = color;
                }
            }
        }
    }
}
