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
    public class IndexModel : PageModel
    {
        private readonly npresume2.Data.npresume2Context _context;

        public IndexModel(npresume2.Data.npresume2Context context)
        {
            _context = context;
        }

        public IList<NpRegistration> NpRegistration { get;set; }

        public async Task OnGetAsync()
        {
            NpRegistration = await _context.NpRegistration.ToListAsync();
        }
    }
}
