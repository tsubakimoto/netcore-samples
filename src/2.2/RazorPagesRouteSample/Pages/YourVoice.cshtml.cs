using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesRouteSample.Pages
{
    public class YourVoiceModel : PageModel
    {
        [TempData]
        public string Text { get; set; }

        public void OnGet(string text = null)
        {
            Text = text;
        }
    }
}