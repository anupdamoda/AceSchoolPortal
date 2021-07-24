using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.ViewModels
{
    public class NewStudentViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
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
        public ICollection<Enrollment> Enrollments
        {
            get; set;
        }
    }
}
