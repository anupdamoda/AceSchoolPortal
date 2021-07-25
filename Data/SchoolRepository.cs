using AceSchoolPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.Data
{
    public class SchoolRepository: ISchoolRepository
    {
        private readonly SchoolContext _ctx;

        public SchoolRepository(SchoolContext ctx)
        {
            _ctx = ctx;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public void RemoveEntity(object model)
        {
            _ctx.Remove(model);
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _ctx.Users
                .OrderBy(u => u.FirstName)
                .ToList();
        }

        public IEnumerable<Students> GetAllStudents()
        {
            return _ctx.Students
                .OrderBy(u => u.first_name)
                .ToList();
        }

        public IList<Users> ListAllUsers()
        {
            return _ctx.Users
                .OrderBy(u => u.FirstName)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
