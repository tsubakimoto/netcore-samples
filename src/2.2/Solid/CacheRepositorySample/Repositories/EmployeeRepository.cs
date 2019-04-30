using CacheRepositorySample.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CacheRepositorySample.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CacheRepositorySampleContext db;

        public EmployeeRepository(CacheRepositorySampleContext db) => this.db = db;

        public void Create(Employee entity)
        {
            if (entity != null)
            {
                db.Employee.Add(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Employee> ReadAll() => db.Employee.ToList();

        public Employee ReadOne(int identity) => db.Find<Employee>(identity);

        public void Update(Employee entity)
        {
            if (entity != null)
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
