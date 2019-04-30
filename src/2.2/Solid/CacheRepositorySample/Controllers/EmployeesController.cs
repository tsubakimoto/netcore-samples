using CacheRepositorySample.Models;
using CacheRepositorySample.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CacheRepositorySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository) => this.employeeRepository = employeeRepository;

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> GetEmployee() => employeeRepository.ReadAll();

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = employeeRepository.ReadOne(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            employeeRepository.Update(employee);
            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult<Employee> PostEmployee(Employee employee)
        {
            employeeRepository.Create(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeID }, employee);
        }

#if false
        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
#endif
    }
}
