using AceSchoolPortal.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace AceSchoolPortal.Data
{
    public interface ISchoolRepository
    {
        IEnumerable<Users> GetAllUsers();
        IList<Users> ListAllUsers();
        IEnumerable<Students> GetAllStudents();
        IEnumerable<Instructors> GetAllInstructors();
        IEnumerable<Subjects> GetAllSubjects();
        void AddEntity(object model);
        void RemoveEntity(object model);
        bool SaveAll();
    }
}