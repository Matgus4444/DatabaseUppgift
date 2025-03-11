using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseTest;

namespace DatabaseTest
{
    internal class UI
    {
        DatabaseHandler DbH = new DatabaseHandler();

        public void PrintMenu()
        {
            Console.WriteLine("1. Register new student.");
            Console.WriteLine("2. Edit student.");
            Console.WriteLine("3. List all students.");
        }

        public void CreateStudent()
        {
            Student s = new Student();
            Console.WriteLine("First name: ");
            s.FirstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            s.LastName = Console.ReadLine();
            Console.WriteLine("City: ");
            s.City = Console.ReadLine();
            DbH.AddStudent(s);
        }

        public void PrintStudents()
        {
            if (DbH.PopCheckDB() )
            { 
            List<Student> Students = DbH.GenerateStudentsList();

            foreach (Student s in Students)
            {
                Console.WriteLine($"{s.FirstName} {s.LastName} {s.City}");
            }
            }
            else
            {
                Console.WriteLine("Database is empty");
            }
        }

        public void EditStudent()
        {
            if (DbH.PopCheckDB())
            {
                Console.WriteLine("Name to search after (first or last name): ");
                string nameSearch = Console.ReadLine();
                var Students = DbH.StudentsMatchesList(nameSearch);
                foreach (Student item in Students)
                {
                    Console.WriteLine($"{item.StudentId} {item.FirstName} {item.LastName} {item.City}");
                }
                Console.WriteLine("Choose student by ID to edit: ");
                int studentEditByID = int.Parse(Console.ReadLine());
                Console.WriteLine("What do you want to change?");
                Console.WriteLine("1. First name");
                Console.WriteLine("2. Last name");
                Console.WriteLine("3. City");
                Console.WriteLine("4. Delete student");
                int studentDataEdit = int.Parse(Console.ReadLine());
                DbH.EditStudent(studentEditByID, studentDataEdit);
            }
            else
            {
                Console.WriteLine("Database is empty");
            }
        }

    }
}

