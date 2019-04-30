using CacheRepositorySample.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace CacheRepositorySample.Repositories
{
    public class CacheEmployeeRepository : IRead<Employee>, ICreateUpdate<Employee>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMemoryCache cache;

        public CacheEmployeeRepository(IEmployeeRepository employeeRepository, IMemoryCache cache)
        {
            this.employeeRepository = employeeRepository;
            this.cache = cache;
        }

        public void Create(Employee entity)
        {
            employeeRepository.Create(entity);
            cache.Set($"employee_{entity.EmployeeID}", entity, TimeSpan.FromSeconds(3));
        }

        public IEnumerable<Employee> ReadAll()
        {
            return cache.GetOrCreate("all_employees", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return employeeRepository.ReadAll();
            });
        }

        public Employee ReadOne(int identity)
        {
            return cache.GetOrCreate($"employee_{identity}", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return employeeRepository.ReadOne(identity);
            });
        }

        public void Update(Employee entity)
        {
            employeeRepository.Update(entity);
            cache.Remove($"employee_{entity.EmployeeID}");
            cache.Set($"employee_{entity.EmployeeID}", entity, TimeSpan.FromSeconds(3));
        }
    }
}
