﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestTaskVodokanal.Models;

namespace TestTaskVodokanal.Pages.ApplicationPages
{
    public class IndexModel : PageModel
    {
        private readonly TestTaskVodokanal.Models.TestTaskVodokanalContext _context;

        public IndexModel(TestTaskVodokanal.Models.TestTaskVodokanalContext context)
        {
            _context = context;
        }

        public IList<Application> Application { get;set; }

        public async Task OnGetAsync()
        {
            Application = await _context.Application.ToListAsync();
        }
    }
}