#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using npresume2.Data;
using npresume2.Model;

namespace npresume2.Pages.Registration
{
    public class EditModel : PageModel
    {
        private readonly npresume2.Data.npresume2Context _context;

        public EditModel(npresume2.Data.npresume2Context context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NpRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NpRegistrationExists(NpRegistration.Npid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NpRegistrationExists(int id)
        {
            return _context.NpRegistration.Any(e => e.Npid == id);
        }
    }
}
