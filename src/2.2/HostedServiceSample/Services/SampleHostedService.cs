using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostedServiceSample.Services
{
    public class SampleHostedService : IHostedService
    {
        private readonly ILogger<SampleHostedService> logger;

        public SampleHostedService(ILogger<SampleHostedService> logger)
        {
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Hosted service starting");

            return Task.Factory.StartNew(async () =>
            {
                // loop until a cancalation is requested
                while (!cancellationToken.IsCancellationRequested)
                {
                    logger.LogInformation("Hosted service executing - {0}", DateTime.Now);
                    try
                    {
                        // wait for 3 seconds
                        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
                    }
                    catch (OperationCanceledException) { }
                }
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Hosted service stopping");
            return Task.CompletedTask;
        }
    }
}
