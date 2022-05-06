using Microsoft.AspNetCore.Mvc;
using RedisCacheSample.Models;

namespace RedisCacheSample.Controllers
{
    public class PersonsController : Controller
    {
        [HttpGet]
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