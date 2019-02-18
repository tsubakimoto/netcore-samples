using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDataProtectionSample.Models
{
    public class EfCoreDataProtectionSampleContext : DbContext
    {
        public EfCoreDataProtectionSampleContext (DbContextOptions<EfCoreDataProtectionSampleContext> options)
            : base(options)
        {
        }

        public DbSet<EfCoreDataProtectionSample.Models.Person> Person { get; set; }
    }
}
