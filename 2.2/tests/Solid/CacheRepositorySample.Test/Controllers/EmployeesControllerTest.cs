using CacheRepositorySample.Controllers;
using CacheRepositorySample.Models;
using CacheRepositorySample.Repositories;
using GenFu;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System.Linq;
using Xunit;

namespace CacheRepositorySample.Test.Controllers
{
    public class EmployeesControllerTest
    {
        [Fact]
        void Success_GetEmployee()
        {
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository
                .Setup(_ => _.ReadAll())
                .Returns(A.ListOf<Employee>(3));

            var mockCache = new Mock<IDistributedCache>();
            var repository = new CacheEmployeeRepository(mockRepository.Object, mockCache.Object);
            var ctrl = new EmployeesController(repository);

            var actual = ctrl.GetEmployee();
            Assert.NotNull(actual);
            Assert.Equal(3, actual.Count());
        }
    }
}
