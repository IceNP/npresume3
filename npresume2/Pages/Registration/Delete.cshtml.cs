#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using npresume2.Data;
using npresume2.Model;

namespace npresume2.Pages.Registration
{
    public class DeleteModel : PageModel
    {
        private readonly npresume2.Data.npresume2Context _context;

        public DeleteModel(npresume2.Data.npresume2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public NpRegistration NpRegistration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NpRegistration = await _context.NpRegistration.FirstOrDefaultAsync(m => m.Npid == id);

            if (NpRegistration == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NpRegistration = await _context.NpRegistration.FindAsync(id);

            if (NpRegistration != null)
            {
                _context.NpRegistration.Remove(NpRegistration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
