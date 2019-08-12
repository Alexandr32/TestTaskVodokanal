using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestTaskVodokanal.Models
{
    public class TestTaskVodokanalContext : DbContext
    {
        public TestTaskVodokanalContext (DbContextOptions<TestTaskVodokanalContext> options)
            : base(options)
        {
        }

        public DbSet<TestTaskVodokanal.Models.Application> Application { get; set; }
    }
}
