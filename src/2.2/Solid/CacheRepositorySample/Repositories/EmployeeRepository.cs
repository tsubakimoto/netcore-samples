using CacheRepositorySample.Models;

namespace CacheRepositorySample.Repositories
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CacheRepositorySampleContext db) : base(db) { }
    }
}
