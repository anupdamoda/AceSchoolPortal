﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data.Entities
{
        public enum Grade
        {
            A, B, C, D, F
        }

        public class Enrollments
        {
        public int EnrollmentId { get; set; }
        //public int CourseID { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        ////public Course Course { get; set; }
        public Students Student { get; set; }
    }
    
}
