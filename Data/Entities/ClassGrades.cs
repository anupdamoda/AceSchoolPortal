using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data.Entities
{
    public class ClassGrades
    {
        public int class_grade_id { get; set; }
        public string class_grade_name { get; set; }
        public string last_name { get; set; }
        public virtual Students Students { get; set; }
        public virtual Instructors Instructors { get; set; }
        public virtual Subjects Subjects { get; set; }
        public DateTime created_at { get; set; }

    }
}
