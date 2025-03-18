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

        public bool IsDatabasePopulated() 
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

        public List<Student> NameMatchedStudentsFromDatabase(string nameSearch)
        {
            var Students = (DbCtx.Students.Where(s => s.FirstName == nameSearch).ToList());
            Students.AddRange(DbCtx.Students.Where(s => s.LastName == nameSearch).ToList());
            return Students;
        }

        public Student IDMatchedStudentFromDatabase(int studentEditByID)
        {
            var student = DbCtx.Students.Where(s => s.StudentId == studentEditByID).FirstOrDefault<Student>();
            return student; //Null hanteras i GetAndValidateStudentID i UI
        }


        public void EditStudent(Student student, int studentDataEdit)
        {
            switch (studentDataEdit)
            {
                case 1:
                    Console.WriteLine("New first name: ");
                    student.FirstName = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("New last name: ");
                    student.LastName = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("New city: ");
                    student.City = Console.ReadLine();
                    break;
                case 4:
                    DbCtx.Remove(student);
                    break;
            }
            DbCtx.SaveChanges();
        }

    }
}
