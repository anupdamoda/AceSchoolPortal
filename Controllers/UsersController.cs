using AceSchoolPortal.Data;
using AceSchoolPortal.Data.Entities;
using AceSchoolPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Controllers
{
    public class UsersController : Controller
    {
        private readonly ISchoolRepository _repository;
     

        public UsersController(ISchoolRepository repository)
        {
            _repository = repository;
        }

        //public ActionResult Edit(string username)
        //{
        //    ////Users User = db.Users.Find(username);
        //    //var user = db.Users.Where(u => u.UserName == username).FirstOrDefault();
        //    //return View(user);
        //}
    }

}
