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
    public class StudentController : Controller
    {
        private readonly ISchoolRepository _repository;
        private readonly SchoolContext db;

        public StudentController(ISchoolRepository repository, SchoolContext db)
        {
            _repository = repository;
            this.db = db;
        }

        public IActionResult NewStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewStudent(NewStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newStudent = new Students()
                {
                    FirstName = model.FirstName,
                    FathersName = model.FathersName,
                    DOJ = model.DOJ,
                    DOB = model.DOB,
                    Grade = model.Grade,
                    MothersName = model.MothersName,
                    BloodGroup = model.BloodGroup,
                    EmergencyContact = model.EmergencyContact,
                    Address = model.Address
                };

                _repository.AddEntity(newStudent);

                _repository.SaveAll();
            }
            else
            {
                //show errors
            }

            return RedirectToAction("StudentManagement");

        }

        public IActionResult StudentManagement()
        {
            ViewBag.Title = "Shop";
            var results = /*from p in _context*/_repository/*.Products*/.GetAllStudents();
            //orderby p.Category
            //select p;

            return View(results.ToList());
        }

        public IActionResult Edit(int id)
        {
            //here, get the user from the database in the real application
            //getting a user from collection for demo purpose
            var usr = _repository.GetAllStudents().Where(s => s.StudentId == id).FirstOrDefault();

            return View(usr);
        }

        [HttpPost]
        public ActionResult Edit(Students std)
        {
            //update user in DB using EntityFramework in real-life application

            //update list by removing old user and adding updated user for demo purpose
            var student = _repository.GetAllStudents().Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            _repository.RemoveEntity(student);
            _repository.AddEntity(std);
            _repository.SaveAll();

            return RedirectToAction("StudentManagement");
        }

        public IActionResult Delete(int id)
        {
            //here, get the student from the database in the real application
            //getting a student from collection for demo purpose
            var std = _repository.GetAllStudents().Where(s => s.StudentId == id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public ActionResult Delete(Students std)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var user = _repository.GetAllStudents().Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            _repository.RemoveEntity(user);
            _repository.SaveAll();

            return RedirectToAction("StudentManagement");
        }

    }

}

