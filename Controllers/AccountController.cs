using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceSchoolPortal.Data.Entities;
using AceSchoolPortal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AceSchoolPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<StoreUser> _signInManager;
        private readonly UserManager<StoreUser> _userManager;
       

        public AccountController(ILogger<AccountController> logger,
            SignInManager<StoreUser> signInManager,
            UserManager<StoreUser> userManager,
            IConfiguration config)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
           
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "App");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,
                    model.Password,
                    model.RememberMe,
                    false);

                if (result.Succeeded)
                {
                    //once signed in 
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Home", "App");
                    }
                }
            }
            ModelState.AddModelError("", "Failed to Login");
            return View();
        }

        public IActionResult NewRegistration()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRegistration(StoreUser user)
        {
            
            var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create new user in Seeder");
            }
            return View();
        }
    }
    }