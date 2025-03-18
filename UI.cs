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
        DatabaseHandler DatabaseHandler = new DatabaseHandler();

        public void PrintMenu(int submenu)
        {
            switch (submenu)
            {
                case 0:
                    Console.WriteLine("1. Register new student.");
                    Console.WriteLine("2. Edit student.");
                    Console.WriteLine("3. List all students.");
                    break;
                case 1:
                    Console.WriteLine("What do you want to edit?");
                    Console.WriteLine("1. First name");
                    Console.WriteLine("2. Last name");
                    Console.WriteLine("3. City");
                    Console.WriteLine("4. Delete student");
                    break;
            }
        }

        public void CreateStudent()
        {
            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            Student student = new Student(firstName, lastName, city);
            DatabaseHandler.AddStudent(student);
        }

        public void PrintStudents()
        {
            if (DatabaseHandler.PopCheckDB())
            {
                List<Student> Students = DatabaseHandler.GenerateStudentsList();
                PrintForeachStudent(Students);
            }
            else
            {
                Console.WriteLine("Database is empty");
            }
        }

        private static void PrintForeachStudent(List<Student> Students)
        {
            foreach (Student s in Students)
            {
                Console.WriteLine($"{s.StudentId} {s.FirstName} {s.LastName} {s.City}");
            }
        }

        public void EditStudent()
        {
            if (DatabaseHandler.PopCheckDB())
            {
                List<Student> Students;
                while (true)
                {
                    Console.WriteLine("Name to search after (first or last name): ");
                    string nameSearch = Console.ReadLine();
                    if (nameSearch == "")
                    {
                        Students = DatabaseHandler.GenerateStudentsList();
                    }
                    else
                    {
                        Students = DatabaseHandler.StudentsMatchesList(nameSearch);
                    }

                    if (Students.Count == 0)
                    {
                        Console.WriteLine($"No students with the name {nameSearch} was found. Please try again. Press enter to see all students.");
                    }
                    else
                    {
                        break;
                    }
                }

                PrintForeachStudent(Students);
                int studentEditByID = GetAndValidateStudentID();
                PrintMenu(1);

                int studentDataEdit = int.Parse(Console.ReadLine());
                DatabaseHandler.EditStudent(studentEditByID, studentDataEdit);
            }
            else
            {
                Console.WriteLine("Database is empty");
            }

            int GetAndValidateStudentID()
            {
                int studentEditByID = 0;
                while (true)
                {
                    bool done = false;
                    do
                    {
                        Console.WriteLine("Choose student by ID to edit: ");
                        try
                        {
                            studentEditByID = int.Parse(Console.ReadLine());
                            done = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Only numbers. Try again.");
                        }
                    } while (!done);

                    Student student = DatabaseHandler.FindStudent(studentEditByID);
                    if (student == null)
                    {
                        Console.WriteLine($"Student with ID {studentEditByID} not found.");
                    }
                    else
                    {
                        break;
                    }
                }

                return studentEditByID;
            }
        }

    }
}

