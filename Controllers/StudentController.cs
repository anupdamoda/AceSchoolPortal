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

    }

}

