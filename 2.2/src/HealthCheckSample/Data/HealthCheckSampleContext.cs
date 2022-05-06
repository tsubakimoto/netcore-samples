using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HealthCheckSample.Models
{
    public class HealthCheckSampleContext : DbContext
    {
        public HealthCheckSampleContext (DbContextOptions<HealthCheckSampleContext> options)
            : base(options)
        {
        }

        public DbSet<HealthCheckSample.Models.Movie> Movie { get; set; }
    }
}
