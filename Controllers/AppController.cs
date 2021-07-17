using AceSchoolPortal.Data;
using AceSchoolPortal.Data.Entities;
using AceSchoolPortal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Controllers
{
    public class AppController : Controller
    {
        private readonly ISchoolRepository _repository;
        private readonly SchoolContext db;

        public AppController(ISchoolRepository repository, SchoolContext db)
        {
            _repository = repository;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewRegistration()
        {
            return View();
        }

        public IActionResult NewStudent()
        {
            return View();
        }

        public async Task<IActionResult> UserManagement(string searchString)
        {
            ViewBag.Title = "Shop";
            var results = /*from p in _context*/_repository/*.Products*/.GetAllUsers();
            //orderby p.Category
            //select p;

            /* for filter by name */
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            return View(results.ToList());
        }

        public IActionResult StudentManagement()
        {
            ViewBag.Title = "Shop";
            var results = /*from p in _context*/_repository/*.Products*/.GetAllStudents();
            //orderby p.Category
            //select p;

            return View(results.ToList());
        }

        [HttpPost]
        public IActionResult NewRegistration(NewRegstnViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new Users()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    UserName = model.EmailAddress,
                    Password = model.Password,
                    ContactNo = model.ContactNo
                };

                _repository.AddEntity(newUser);
                _repository.SaveAll();

            }
            else
            {
                //show errors
            }
            return View();
        }


        public IActionResult Edit(string id)
        {
            //here, get the user from the database in the real application
            //getting a user from collection for demo purpose
            var usr = _repository.ListAllUsers().Where(u => u.UserName == id).FirstOrDefault();

            return View(usr);
        }

        [HttpPost]
        public ActionResult Edit(Users usr)
        {
            //update user in DB using EntityFramework in real-life application

            //update list by removing old user and adding updated user for demo purpose
            var user = _repository.ListAllUsers().Where(u => u.UserName == usr.UserName).FirstOrDefault();
            _repository.RemoveEntity(user);
            _repository.AddEntity(usr);
            _repository.SaveAll();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            //here, get the user from the database in the real application
            //getting a user from collection for demo purpose
            var usr = _repository.ListAllUsers().Where(u => u.UserName == id).FirstOrDefault();
            return View(usr);
        }

        [HttpPost]
        public ActionResult Delete(Users usr)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var user = _repository.ListAllUsers().Where(u => u.UserName == usr.UserName).FirstOrDefault();
            _repository.RemoveEntity(user);
            _repository.SaveAll();

            return RedirectToAction("Index");
        }
    }
 }
