﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestTaskVodokanal.Models;
using TestTaskVodokanal.Models.ViewModels;

namespace TestTaskVodokanal.Pages.ApplicationPages
{
    public class EditModel : PageModel
    {
        private readonly TestTaskVodokanal.Models.TestTaskVodokanalContext _context;

        public EditModel(TestTaskVodokanal.Models.TestTaskVodokanalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Application Application { get; set; }
        
        /// <summary>
        /// История завки
        /// </summary>
        public IEnumerable<History> History { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Подтягивание данных
            //Application = await _context.Application.Include(b => b.ChangeHistory).FirstAsync();
            Application = await _context.Application
                .Include(b => b.ChangeHistory)
                .FirstAsync(s => s.ApplicationID == id);

            
            if (Application == null)
            {
                return NotFound();
            }

            //Application = await _context.Application.FirstOrDefaultAsync(m => m.ApplicationID == id);
            //Application = await _context.Application.Include(s => s.ChangeHistory).ToListAsync().Single(s => s.ApplicationID == id.Value);
            //Historys = Application.ChangeHistory.Where(s => s.ApplicationId == id);
            History = Application.ChangeHistory.Where(s => s.ApplicationId == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(Application.ApplicationID))
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

        private bool ApplicationExists(int id)
        {
            return _context.Application.Any(e => e.ApplicationID == id);
        }
    }
}
