#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EfCoreSample.Data;
using EfCoreSample.Models;

namespace EfCoreSample.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly EfCoreSample.Data.SampleDatabaseContext _context;

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }

        public IndexModel(EfCoreSample.Data.SampleDatabaseContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            CurrentFilter = searchString;

            /*
            Product = await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel).ToListAsync();
            */

            var productsIQ = from p in _context.Products
                             select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                productsIQ = productsIQ.Where(p => p.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    productsIQ = productsIQ.OrderByDescending(p => p.Name);
                    break;
                default:
                    productsIQ = productsIQ.OrderBy(p => p.Name);
                    break;
            }

            Product = await productsIQ.AsNoTracking().ToListAsync();
        }
    }
}
