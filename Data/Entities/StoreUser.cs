﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data.Entities
{
        public class StoreUser : IdentityUser
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool? isEnabled { get; set; }
        }
}
