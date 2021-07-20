using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data.Entities
{
    public class Students
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public DateTime DOB { get; set; }
        public string Grade { get; set; }
        public DateTime DOJ { get; set; }
        public string BloodGroup {get; set;}
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
    }
}
