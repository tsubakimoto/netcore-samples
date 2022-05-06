using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisCacheSample.Models;

namespace RedisCacheSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistributedCache cache;

        public HomeController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CachedTime = "Cached Time Expired";
            var encodedCachedTimeUTC = await cache.GetAsync("cachedTimeUTC");
            if (encodedCachedTimeUTC != null)
            {
                ViewBag.CachedTime = Encoding.UTF8.GetString(encodedCachedTimeUTC);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Reset()
        {
            var currentTimeUTC = DateTime.UtcNow.ToString();
            byte[] encodedCurrentTimeUTC = Encoding.UTF8.GetBytes(currentTimeUTC);
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(20));
            await cache.SetAsync("cachedTimeUTC", encodedCurrentTimeUTC, options);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
