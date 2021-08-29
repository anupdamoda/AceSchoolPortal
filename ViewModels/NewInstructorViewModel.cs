using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.ViewModels
{
    public class NewInstructorViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstructorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Experience { get; set; }
        public DateTime Enrollmentdate { get; set; }
    }
}
