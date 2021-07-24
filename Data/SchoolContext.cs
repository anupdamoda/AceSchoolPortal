﻿using AceSchoolPortal.Data.Entities;
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
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Students> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>()
                .HasKey(u => new { u.UserName });
            modelBuilder.Entity<Students>()
                .HasKey(s => new { s.StudentId });
            modelBuilder.Entity<Enrollments>()
                .HasKey(e => new { e.EnrollmentId });
            modelBuilder.Entity<Subjects>()
                .HasKey(s => new { s.SubjectId});
            //.HasData()
        }

    }
}