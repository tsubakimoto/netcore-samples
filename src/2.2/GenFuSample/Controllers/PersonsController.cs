using GenFu;
using GenFuSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GenFuSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            // Generate relational data
            A.Configure<Company>()
                .Fill(c => c.Id).WithinRange(1, 5);
            var companies = A.ListOf<Company>(10);

            // Generate main data
            A.Configure<Person>()
                .Fill(p => p.CompanyId).WithinRange(1, 5);
            var persons = A.ListOf<Person>(5);

            // Set relational data
            foreach (var p in persons)
            {
                p.Company = companies.FirstOrDefault(c => c.Id == p.CompanyId);
            }

            return persons;
        }
    }
}