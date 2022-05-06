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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, Name = "employee1" },
                new Employee { EmployeeID = 2, Name = "employee2" },
                new Employee { EmployeeID = 3, Name = "employee3" }
            );
        }

        public DbSet<CacheRepositorySample.Models.Employee> Employee { get; set; }
    }
}
