using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    internal class DatabaseHandler
    {

        StudentDbContext DbCtx = new StudentDbContext();

        public bool PopCheckDB()
        {
            if (DbCtx.Students.Count() != 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public void AddStudent(Student student)
        {
            DbCtx.Add(student);
            DbCtx.SaveChanges();
        }

        public List<Student> GenerateStudentsList()
        {
            var Students = DbCtx.Students.ToList();
            return Students;
        }

        public List<Student> StudentsMatchesList(string nameSearch)
        {

            var Students = (DbCtx.Students.Where(s => s.FirstName == nameSearch).ToList());
            Students.AddRange(DbCtx.Students.Where(s => s.LastName == nameSearch).ToList());
            return Students;
        }

        public void EditStudent(int studentEditByID, int studentDataEdit)
        {
            var s = DbCtx.Students.Where(s => s.StudentId == studentEditByID).FirstOrDefault<Student>();
            switch (studentDataEdit)
            {
                case 1:
                    Console.WriteLine("New first name: ");
                    s.FirstName = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("New last name: ");
                    s.LastName = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("New city: ");
                    s.City = Console.ReadLine();
                    break;
                case 4:
                    DbCtx.Remove(s);
                    break;
            }
            DbCtx.SaveChanges();
        }
    }
}
