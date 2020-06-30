using DomainModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IStudentRepository : IRepository<Student, string>
    {
        IEnumerable<Student> GetOutStandingStudents(int year);
        IEnumerable<Student> GetCompletedCourses();
    }
}
