using AceSchoolPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data
{
    public class SchoolContext: DbContext
    {
       

        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>()
                .HasKey(u => new { u.UserName });
            modelBuilder.Entity<Students>()
                .HasKey(s => new { s.DOB });
            //.HasData()
        }

    }
}
