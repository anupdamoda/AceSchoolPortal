using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data.Entities
{
    public class Instructors
    {
        public int instructor_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int experience { get; set; }
        public DateTime enrollment_date { get; set; }
        public DateTime created_at {get; set;}
        public ICollection<ClassGrades> ClassGrades { get; set; }

    }
}
