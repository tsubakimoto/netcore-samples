using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LoggingSample.Logging.Configuration;
using LoggingSample.Logging.Provider;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoggingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    // Built-in logger
                    //logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    //logging.AddConsole();
                    //logging.AddDebug();

                    // Custom logger
                    logging.ClearProviders();
                    var config = new ColoredConsoleLoggerConfiguration
                    {
                        LogLevel = LogLevel.Information,
                        Color = ConsoleColor.Yellow
                    };
                    logging.AddProvider(new ColoredConsoleLoggerProvider(config));
                })
                .UseStartup<Startup>();
    }
}
