using AceSchoolPortal.Data;
using AceSchoolPortal.Data.Entities;
using AceSchoolPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISchoolRepository _repository;
        private readonly SchoolContext db;

        public SubjectsController(ISchoolRepository repository, SchoolContext db)
        {
            _repository = repository;
            this.db = db;
        }

        public IActionResult NewSubject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewSubject(NewSubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newSubject = new Subjects()
                {
                    subject_name = model.SubjectName,
                    // created date should be the date as created
                    created_at = DateTime.Now,
                    // updated date should be same as created date before it gets updated 
                    updated_at = DateTime.Now
                };

                _repository.AddEntity(newSubject);

                _repository.SaveAll();
            }
            else
            {
                //show errors
            }

            return RedirectToAction("SubjectMngmnt");

        }

        [Authorize]
        public IActionResult SubjectMngmnt(string searchString, int? page, string currentFilter)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var results = /*from p in _context*/_repository/*.Products*/.GetAllSubjects();
            //orderby p.Category
            //select p;

            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.subject_name.Contains(searchString));
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(results.ToPagedList(pageNumber,pageSize));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            //here, get the user from the database in the real application
            //getting a user from collection for demo purpose
            var usr = _repository.GetAllSubjects().Where(s => s.subject_id == id).FirstOrDefault();
            return View(usr);
        }

        [HttpPost]
        public IActionResult Edit(Subjects sub)
        {
            //update subjects in DB using EntityFramework in real-life application

            //update list by removing old user and adding updated user for demo purpose
            var subject = _repository.GetAllSubjects().Where(s => s.subject_id == sub.subject_id).FirstOrDefault();
            _repository.RemoveEntity(subject);
            // created date should remain the same
            sub.created_at = subject.created_at;
            // edited/updated date should be updated to current date (date of the edit)
            sub.updated_at = DateTime.Now;
            _repository.RemoveEntity(subject);
            _repository.AddEntity(sub);
            _repository.SaveAll();

            return RedirectToAction("SubjectMngmnt");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            //here, get the student from the database in the real application
            //getting a student from collection for demo purpose
            var sub = _repository.GetAllSubjects().Where(s => s.subject_id == id).FirstOrDefault();
            return View(sub);
        }

        [HttpPost]
        public ActionResult Delete(Subjects sub)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var subject = _repository.GetAllSubjects().Where(s => s.subject_id == sub.subject_id).FirstOrDefault();
            _repository.RemoveEntity(subject);
            _repository.SaveAll();

            return RedirectToAction("SubjectMngmnt");
        }

    }

}

