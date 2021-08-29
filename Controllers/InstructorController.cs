using AceSchoolPortal.Data;
using AceSchoolPortal.Data.Entities;
using AceSchoolPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ISchoolRepository _repository;
        private readonly SchoolContext db;

        public InstructorController(ISchoolRepository repository, SchoolContext db)
        {
            _repository = repository;
            this.db = db;
        }

        public IActionResult NewInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewInstructor(NewInstructorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newInstructor = new Instructors()
                {
                    first_name = model.FirstName,
                    last_name = model.LastName,
                    experience = model.Experience,
                    enrollment_date = model.Enrollmentdate,
                    created_at = DateTime.Now
                };

                _repository.AddEntity(newInstructor);

                _repository.SaveAll();
            }
            else
            {
                //show errors
            }

            return RedirectToAction("InstructorManagement");

        }

        [Authorize]
        public IActionResult InstructorManagement(string searchString)

        {
            var results = /*from p in _context*/_repository/*.Products*/.GetAllInstructors();
            //orderby p.Category
            //select p;

            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.last_name.Contains(searchString)
                                       || s.first_name.Contains(searchString));
            }

            return View(results.ToList());
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            //here, get the user from the database in the real application
            //getting a user from collection for demo purpose
            var usr = _repository.GetAllInstructors().Where(s => s.instructor_id == id).FirstOrDefault();

            return View(usr);
        }

        [HttpPost]
        public ActionResult Edit(Instructors inst)
        {
            //update user in DB using EntityFramework in real-life application

            //update list by removing old user and adding updated user for demo purpose
            var instructor = _repository.GetAllStudents().Where(s => s.student_id == inst.instructor_id).FirstOrDefault();
            _repository.RemoveEntity(instructor);
            _repository.AddEntity(inst);
            _repository.SaveAll();

            return RedirectToAction("InstructorManagement");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            //here, get the student from the database in the real application
            //getting a student from collection for demo purpose
            var std = _repository.GetAllInstructors().Where(s => s.instructor_id == id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public ActionResult Delete(Instructors inst)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var user = _repository.GetAllInstructors().Where(s => s.instructor_id == inst.instructor_id).FirstOrDefault();
            _repository.RemoveEntity(user);
            _repository.SaveAll();

            return RedirectToAction("InstructorManagement");
        }

    }

}

