using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace AppConfigurationConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(Environment.GetEnvironmentVariable("ConnectionStrings:AppConfig"));

            var config = builder.Build();
            Console.WriteLine(config["AppConfigurationConsoleSample:Settings:Message"] ?? "Hello world!");
        }
    }
}
