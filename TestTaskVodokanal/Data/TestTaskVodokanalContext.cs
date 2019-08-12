using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTaskVodokanal.Models;

namespace TestTaskVodokanal.Models
{
    public class TestTaskVodokanalContext : DbContext
    {
        public TestTaskVodokanalContext (DbContextOptions<TestTaskVodokanalContext> options)
            : base(options)
        {
        }

        public DbSet<TestTaskVodokanal.Models.Application> Application { get; set; }

        public DbSet<TestTaskVodokanal.Models.History> History { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Application>().ToTable("Application");
        //    modelBuilder.Entity<History>().ToTable("History");

        //    modelBuilder.Entity<History>()
        //        .HasKey(c => new { c.ApplicationId });
        //}
    }
}
