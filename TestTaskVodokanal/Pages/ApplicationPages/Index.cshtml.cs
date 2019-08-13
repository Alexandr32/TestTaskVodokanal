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
    public class IndexModel : PageModel
    {
        public int ApplicationID { get; set; }
        public ApplicationIndexData Application { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTimeSort DateTimeSort { get; set; }

        [BindProperty(SupportsGet = true)]

        /// <summary>
        /// Свойство для сортировки по статусу
        /// </summary>
        public Status SelectSortStatus { get; set; }

        /// <summary>
        /// Свойство для текущей сортировки
        /// </summary>
        public string CurrentSort { get; set; }
        /// <summary>
        /// Свойства для сортировки по статусу
        /// </summary>
        public string StatusSort { get; set; }

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
                    .Where(s => s.Status == SelectSortStatus)
                    .Where(s => s.RegistrationDate >= DateTimeSort.DateTimeMin && s.RegistrationDate <= DateTimeSort.DateTimeMax)
                    .Include(s => s.ChangeHistory)
                    //.AsNoTracking() // Выведенный список нет необходимости хранить в кэше
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
                default:
                    Application.Applications = Application.Applications.OrderBy(s => s.Status);
                    break;
            }
        }
    }
}