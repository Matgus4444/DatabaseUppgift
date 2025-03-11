using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    internal class DatabaseHandler
    {
        StudentDbContext DbCtx = new StudentDbContext();
        public void AddStudent(Student student)
        {
            DbCtx.Add(student);
            DbCtx.SaveChanges();
        }

        public List<Student> GenerateStudentsList()
        {
            List<Student> Students = new List<Student>();

            foreach (var item in DbCtx.Students)
            {
                Students.Add(item);
            }
            return Students;
        }

        public List<Student> StudentsMatchesList(string searchField)
        {
            var std = (DbCtx.Students.Where(s => s.FirstName == searchField).<Student>());
        }
    }
}
