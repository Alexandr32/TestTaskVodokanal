using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestTaskVodokanal.Models;
using TestTaskVodokanal.Models.ViewModels;

namespace TestTaskVodokanal.Pages.ApplicationPages
{
    public class IndexModel : PageModel
    {
        public int ApplicationID{ get; set;}
        public ApplicationIndexData Application { get; set; }

        private readonly TestTaskVodokanal.Models.TestTaskVodokanalContext _context;

        public IndexModel(TestTaskVodokanal.Models.TestTaskVodokanalContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int? id)
        {
            Application = new ApplicationIndexData
            {
                Applications = await _context.Application
                .Include(s=>s.ChangeHistory)
                .ToListAsync()
            };

            if (id != null)
            {
                // Узнаем ид выбранного элемента
                ApplicationID = id.Value;
                // Извлекаем заяки по id;
                Application selectApplication = Application.Applications.Single(s => s.ApplicationID == id.Value);
                
                Application.Historys = selectApplication.ChangeHistory.Where(s => s.ApplicationId == id.Value);
            }
        }
    }
}
