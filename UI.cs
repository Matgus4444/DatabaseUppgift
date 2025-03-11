using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    internal class UI
    {
        
        


        public void PrintMenu()
        {
            Console.WriteLine("1. Register new student.");
            Console.WriteLine("2. Edit student.");
            Console.WriteLine("3. List all students.");
        }
        
        public Student CreateStudent()
        {
            Student s1 = new Student();
            Console.WriteLine("First name: ");
            s1.FirstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            s1.LastName = Console.ReadLine();
            Console.WriteLine("City: ");
            s1.City = Console.ReadLine();
            return s1;
        }

        public void PrintStudents(DatabaseHandler DbH)
        {
            List<Student> Students = DbH.GenerateStudentsList();
            foreach (Student s in Students)
            {
                Console.WriteLine($"{s.FirstName} {s.LastName} {s.City}");
            }
        }
        public void EditStudent()
        {
            string searchField = Console.ReadLine();
        }
    }
}
