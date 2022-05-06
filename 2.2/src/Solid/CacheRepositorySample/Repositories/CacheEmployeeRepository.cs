using CacheRepositorySample.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CacheRepositorySample.Repositories
{
    public class CacheEmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDistributedCache cache;

        public CacheEmployeeRepository(IEmployeeRepository employeeRepository, IDistributedCache cache)
        {
            this.employeeRepository = employeeRepository;
            this.cache = cache;
        }

        public void Create(Employee entity)
        {
            employeeRepository.Create(entity);
            cache.SetString(
                $"employee_{entity.EmployeeID}",
                JsonConvert.SerializeObject(entity),
                new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30)));
        }

        public IEnumerable<Employee> ReadAll()
        {
            var cachedEmployees = cache.GetString("all_employees");
            if (!string.IsNullOrWhiteSpace(cachedEmployees))
                return JsonConvert.DeserializeObject<IEnumerable<Employee>>(cachedEmployees);

            var employees = employeeRepository.ReadAll();
            cache.SetString(
                "all_employees",
                JsonConvert.SerializeObject(employees),
                new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30)));
            return employees;
        }

        public Employee ReadOne(int identity)
        {
            var cachedEmployee = cache.GetString($"employee_{identity}");
            if (!string.IsNullOrWhiteSpace(cachedEmployee))
                return JsonConvert.DeserializeObject<Employee>(cachedEmployee);

            var employee = employeeRepository.ReadOne(identity);
            cache.SetString(
                $"employee_{identity}",
                JsonConvert.SerializeObject(employee),
                new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30)));
            return employee;
        }

        public void Update(Employee entity)
        {
            employeeRepository.Update(entity);
            cache.Remove($"employee_{entity.EmployeeID}");
            cache.SetString(
                $"employee_{entity.EmployeeID}",
                JsonConvert.SerializeObject(entity),
                new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30)));
        }
    }
}
