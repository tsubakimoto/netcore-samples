using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CacheRepositorySample.Models
{
    public class CacheRepositorySampleContext : DbContext
    {
        public CacheRepositorySampleContext (DbContextOptions<CacheRepositorySampleContext> options)
            : base(options)
        {
        }

        public DbSet<CacheRepositorySample.Models.Employee> Employee { get; set; }
    }
}
