#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using npresume2.Data;
using npresume2.Model;

namespace npresume2.Pages.Registration
{
    public class CreateModel : PageModel
    {
        private readonly npresume2.Data.npresume2Context _context;

        public CreateModel(npresume2.Data.npresume2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NpRegistration NpRegistration { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NpRegistration.Add(NpRegistration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Create");
        }
    }
}
