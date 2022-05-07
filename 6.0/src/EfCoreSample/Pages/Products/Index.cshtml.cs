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
        private readonly IConfiguration _configuration;

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IndexModel(EfCoreSample.Data.SampleDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //public IList<Product> Product { get;set; }
        public PaginatedList<Product> Product { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString is not null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

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

            //Product = await productsIQ.AsNoTracking().ToListAsync();

            var pageSize = _configuration.GetValue("PageSize", 4);
            Product = await PaginatedList<Product>.CreateAsync(productsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
