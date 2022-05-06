using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ActionFilterSample.Models
{
    public class ActionFilterSampleContext : DbContext
    {
        public ActionFilterSampleContext (DbContextOptions<ActionFilterSampleContext> options)
            : base(options)
        {
        }

        public DbSet<ActionFilterSample.Models.Person> Person { get; set; }
    }
}
