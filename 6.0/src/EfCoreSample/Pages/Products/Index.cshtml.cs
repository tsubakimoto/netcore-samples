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

        public IndexModel(EfCoreSample.Data.SampleDatabaseContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel).ToListAsync();
        }
    }
}
