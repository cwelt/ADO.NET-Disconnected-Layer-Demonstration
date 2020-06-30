using DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class StudentRepository : Repository<Student, string>, IStudentRepository
    {
        public StudentRepository(DataSet dataSet)
        : base(dataSet)
        {

        }


        public IEnumerable<Student> GetCompletedCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetOutStandingStudents(int year)
        {
            throw new NotImplementedException();
        }
    }
}
