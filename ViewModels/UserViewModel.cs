using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string EmailAddress { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }

        public string ContactNo { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsAdmin { get; set; }
    }
}
