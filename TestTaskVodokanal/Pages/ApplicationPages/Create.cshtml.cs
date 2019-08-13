using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestTaskVodokanal.Models;

namespace TestTaskVodokanal.Pages.ApplicationPages
{
    public class CreateModel : PageModel
    {
        private readonly TestTaskVodokanal.Models.TestTaskVodokanalContext _context;

        public CreateModel(TestTaskVodokanal.Models.TestTaskVodokanalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Application Application { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Application.Status = Status.Open;
            Application.RegistrationDate = DateTime.Now;

            _context.Application.Add(Application);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}