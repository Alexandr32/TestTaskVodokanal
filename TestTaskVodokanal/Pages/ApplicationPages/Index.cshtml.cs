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

        /// <summary>
        /// Свойство сортировки
        /// </summary>
        public string CurrentSort { get; set; }
        /// <summary>
        /// Свойства для сортировки имени
        /// </summary>
        public string StatusSort { get; set; }

        /// <summary>
        /// Выбранный статус для поиска
        /// </summary>
        //public Status SelectStatus { get; set; }


        private readonly TestTaskVodokanal.Models.TestTaskVodokanalContext _context;

        public IndexModel(TestTaskVodokanal.Models.TestTaskVodokanalContext context)
        {
            _context = context;
        }       

        public async Task OnGetAsync(int? id, string sortOrder)
        {
            CurrentSort = sortOrder;

            // StatusSort используется как свойтво для фильтрации через asp-route-sortOrder
            // Присваивается противоположное значение относительно текущего параметра сотояния 
            // для дальнейшей сортировки при выборе необходимости сортировки
            StatusSort = string.IsNullOrEmpty(sortOrder) ? "status_desc" : "";

            Application = new ApplicationIndexData
            {
                Applications = await _context.Application
                .Include(s=>s.ChangeHistory)
                .AsNoTracking() // Выведенный список нет необходимости хранить в кэше
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

            // Сортировка в зависимости от переданного параметра
            switch (sortOrder)
            {
                // Выборка по статусу Порядок по убыванию
                case "status_desc":
                    Application.Applications = Application.Applications.OrderByDescending(s => s.Status);
                    break;
                // Выборка по дате Порядок по возростанию
                //case "Date":
                //    studentIQ = studentIQ.OrderBy(s => s.EnrollmentDate);
                //    break;
                //// Выборка по дате порядок по убыванию
                //case "date_desc":
                //    studentIQ = studentIQ.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                // По умолчанию используется порядок сортировки по возрастанию.
                default:
                    Application.Applications = Application.Applications.OrderBy(s => s.Status);
                    break;
            }
        }
    }
}
