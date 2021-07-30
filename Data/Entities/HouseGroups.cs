using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data.Entities
{
    public class HouseGroups
    {
        public int house_group_id { get; set; }
        public string house_group_name { get; set; }
        public virtual Instructors Instructors { get; set; }
        public virtual Students Students { get; set; }
        public DateTime created_at {get; set;}

    }
}
