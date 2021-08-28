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

                var user = await _userManager.FindByEmailAsync(model.Username);

                if (result.Succeeded)
                {
                    if (user.isEnabled == true)
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
                    else
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("NotEnabled", "App");
                    }
                }
            }
            ModelState.AddModelError("", "Entered username or password is wrong");
            return View();
        }

        public IActionResult NewRegistration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRegistration(StoreUser user, NewRegstnViewModel model)
        {
            user.isEnabled = false;
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create new user in Seeder");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }
    }
    }