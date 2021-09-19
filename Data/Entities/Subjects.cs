using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data.Entities
{
    public class Subjects
    {
        public int subject_id { get; set; }
        public string subject_name { get; set; }
        public ICollection<ClassGrades> ClassGrades { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
