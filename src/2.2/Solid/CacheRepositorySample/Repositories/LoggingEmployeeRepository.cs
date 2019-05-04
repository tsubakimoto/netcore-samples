using CacheRepositorySample.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CacheRepositorySample.Repositories
{
    public class LoggingEmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ILogger<LoggingEmployeeRepository> logger;

        public LoggingEmployeeRepository(IEmployeeRepository employeeRepository, ILogger<LoggingEmployeeRepository> logger)
        {
            this.employeeRepository = employeeRepository;
            this.logger = logger;
        }

        public void Create(Employee entity)
        {
            logger.LogInformation("create");
            employeeRepository.Create(entity);
        }

        public IEnumerable<Employee> ReadAll()
        {
            logger.LogInformation("read all");
            return employeeRepository.ReadAll();
        }

        public Employee ReadOne(int identity)
        {
            logger.LogInformation("read one");
            return employeeRepository.ReadOne(identity);
        }

        public void Update(Employee entity)
        {
            logger.LogInformation("update");
            employeeRepository.Update(entity);
        }
    }
}
