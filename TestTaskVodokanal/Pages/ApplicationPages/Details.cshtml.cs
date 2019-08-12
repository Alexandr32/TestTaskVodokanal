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
    public class DetailsModel : PageModel
    {
        private readonly TestTaskVodokanal.Models.TestTaskVodokanalContext _context;

        public DetailsModel(TestTaskVodokanal.Models.TestTaskVodokanalContext context)
        {
            _context = context;
        }

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
    }
}
