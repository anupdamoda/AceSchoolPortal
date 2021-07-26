using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data.Entities
{
    public class Students
    {
        public int student_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime dob { get; set; }
        public string grade { get; set; }
        public DateTime enrollment_date { get; set; }
        public string address { get; set; }
        public virtual ICollection<ClassGrades> ClassGrades { get; set; }
        public virtual ICollection<HouseGroups> HouseGroups { get; set; }
    }
}
