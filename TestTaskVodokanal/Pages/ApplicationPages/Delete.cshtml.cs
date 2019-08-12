using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestTaskVodokanal.Models;

namespace TestTaskVodokanal.Pages.ApplicationPages
{
    public class DeleteModel : PageModel
    {
        private readonly TestTaskVodokanal.Models.TestTaskVodokanalContext _context;

        public DeleteModel(TestTaskVodokanal.Models.TestTaskVodokanalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Application Application { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application = await _context.Application.FirstOrDefaultAsync(m => m.ApplicationID == id);

            if (Application == null)
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

            Application = await _context.Application.FindAsync(id);

            if (Application != null)
            {
                _context.Application.Remove(Application);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
