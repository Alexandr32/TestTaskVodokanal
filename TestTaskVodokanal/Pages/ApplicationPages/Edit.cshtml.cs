using System;
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
        public IEnumerable<History> Historys { get; set; }
        /// <summary>
        /// Свойтво для добавления истории
        /// </summary>
        [BindProperty]
        public History History { get; set; }

        /// <summary>
        /// Следующий возможный статус завки
        /// </summary>
        public Status NextStatus { get; set; }
        /// <summary>
        /// Список возможных статусов
        /// </summary>
        public SelectList SelectListStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Получаем данные из БД и подтягиваем данные
            Application = await _context.Application
                .Include(b => b.ChangeHistory)
                .FirstAsync(s => s.ApplicationID == id);

            
            if (Application == null)
            {
                return NotFound();
            }

            Historys = Application.ChangeHistory.Where(s => s.ApplicationId == id);

            // Проверка статуса
            if (Application.Status == Status.Open)
            {
                //Из статуса «Открыта» заявка переходит в статус «Решена»
                NextStatus = Status.Completed;
                SelectListStatus = new SelectList(new List<Status>() { Status.Completed });
            }
            else if (Application.Status == Status.Completed)
            {
                // Из статуса «Решена» заявка может прейти в статусы «Возврат» или «Закрыта»
                NextStatus = Status.Close;
                SelectListStatus = new SelectList(new List<Status>() { Status.Return, Status.Close });
            }
            else if (Application.Status == Status.Return)
            {
                // Из статуса «Возврат» заявка переходит в статус «Решена».
                NextStatus = Status.Return;
                SelectListStatus = new SelectList(new List<Status>() { Status.Close });
            }
            else if (Application.Status == Status.Close)
            {
                // статус "Закрыто" изменение не происходит.
                NextStatus = Status.Close;
                SelectListStatus = new SelectList(new List<Status>() { Status.Close });
            }

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
