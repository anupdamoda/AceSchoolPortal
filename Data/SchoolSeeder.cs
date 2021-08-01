using AceSchoolPortal.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data
{
    public class SchoolSeeder
    {
        private readonly SchoolContext _ctx;
        private readonly IHostEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public SchoolSeeder(SchoolContext ctx, IHostEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByNameAsync("amarpendlya1999@gmail.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Amar",
                    LastName = "Pendlya",
                    Email = "Amarpendlya1999@gmail.com",
                    UserName = "AmarPendlya1999@gmail.com"
                };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in Seeder");
                }
            }
        }
        }
}
