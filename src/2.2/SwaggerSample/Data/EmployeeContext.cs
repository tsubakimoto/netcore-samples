using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SwaggerSample.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext (DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<SwaggerSample.Models.Employee> Employee { get; set; }
    }
}
