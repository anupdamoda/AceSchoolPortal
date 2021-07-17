using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.ViewModels
{
    public class NewStudentViewModel
    {

        [Required]
        public string FirstName { get; set; }

        public string FathersName { get; set; }
        
        [Required]
        public DateTime DOJ { get; set; }


        public string MothersName { get; set; }
        public DateTime DOB { get; set; }
        public string Grade { get; set; }
        
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
    }
}
