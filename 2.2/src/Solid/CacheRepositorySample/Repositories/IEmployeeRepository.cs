using CacheRepositorySample.Models;

namespace CacheRepositorySample.Repositories
{
    public interface IEmployeeRepository : IRead<Employee>, ICreateUpdate<Employee>
    {
    }
}
