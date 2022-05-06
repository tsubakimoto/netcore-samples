using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDataProtectionSample.Models
{
    public class EfCoreDataProtectionSampleContext : DbContext, IDataProtectionKeyContext
    {
        public EfCoreDataProtectionSampleContext (DbContextOptions<EfCoreDataProtectionSampleContext> options)
            : base(options)
        {
        }

        public DbSet<EfCoreDataProtectionSample.Models.Person> Person { get; set; }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    }
}
