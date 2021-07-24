using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data.Entities
{
    public class Subjects
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }
    }
}
