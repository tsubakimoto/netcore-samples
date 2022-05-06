using Microsoft.AspNetCore.Mvc;
using ModelBinderSample.Models;
using ModelBinderSample.Models.Binders;
using System.Collections.Generic;
using System.Linq;

namespace ModelBinderSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<object> Post(
            [ModelBinder(binderType: typeof(CsvModelBinder))] IEnumerable<Person> persons)
        {
            return new
            {
                ItemsRead = persons.Count(),
                Persons = persons
            };
        }
    }
}