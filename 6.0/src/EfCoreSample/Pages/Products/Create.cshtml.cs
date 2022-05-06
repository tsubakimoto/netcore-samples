#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EfCoreSample.Data;
using EfCoreSample.Models;

namespace EfCoreSample.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly EfCoreSample.Data.SampleDatabaseContext _context;

        public CreateModel(EfCoreSample.Data.SampleDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "ProductCategoryId");
        ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "ProductModelId", "ProductModelId");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
