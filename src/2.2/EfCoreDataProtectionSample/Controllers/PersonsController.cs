using EfCoreDataProtectionSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreDataProtectionSample.Controllers
{
    public class PersonsController : Controller
    {
        private readonly EfCoreDataProtectionSampleContext _context;

        public PersonsController(EfCoreDataProtectionSampleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("Id,Name,Birthday")] Person person)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}
