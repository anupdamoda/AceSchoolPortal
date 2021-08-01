using AceSchoolPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AceSchoolPortal.Data
{
    public class SchoolContext : IdentityDbContext<StoreUser>
    {
        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<ClassGrades> ClassGrades { get; set; }
        public DbSet<Subjects> Subjects{ get; set; }
        public DbSet<HouseGroups> HouseGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>()
                .HasKey(u => new { u.UserName });
            modelBuilder.Entity<Students>()
                .HasKey(s => new { s.student_id });
            modelBuilder.Entity<Instructors>()
                .HasKey(i => new { i.instructor_id });
            modelBuilder.Entity<ClassGrades>()
                .HasKey(c => new { c.class_grade_id });
            modelBuilder.Entity<Subjects>()
                .HasKey(s2 => new { s2.subject_id });
            modelBuilder.Entity<HouseGroups>()
                .HasKey(h => new { h.house_group_id});
            //.HasData()
        }

    }
}
