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
        enum ErrorCodes
        {
            Format,
            EmptyDatabase
        }
        public string ReturnError(int errorCode)
        {
            switch (errorCode)
            {
                case 0:
                    return "Only numbers.";
                case 1:
                    return "Database is empty.";

            }
            return "Unkown exception.";
        }
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
            if (DatabaseHandler.IsDatabasePopulated())
            {
                List<Student> Students = DatabaseHandler.GenerateStudentsList();
                PrintForeachStudent(Students);
            }
            else
            {
                Console.WriteLine(ReturnError((int)ErrorCodes.EmptyDatabase));
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
            if (DatabaseHandler.IsDatabasePopulated())
            {
                //Här blev det en massa lokala metoder för att det inte skulle bli wall of code
                //hoppas det är läsbart
                List<Student> Students = FindInputStudents();
                PrintForeachStudent(Students);
                Student student = GetAndValidateStudent();
                PrintMenu(1);

                int studentPropToEdit = 0; 
                bool done = false;
                do
                {

                    try
                    {
                        studentPropToEdit = int.Parse(Console.ReadLine());
                        done = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(ReturnError((int)ErrorCodes.Format));
                    }
                } while (!done);
                DatabaseHandler.EditStudent(student, studentPropToEdit);
            }
            else
            {
                Console.WriteLine(ReturnError((int)ErrorCodes.EmptyDatabase));
            }

            Student GetAndValidateStudent()
            {
                Student student;
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
                            Console.WriteLine(ReturnError((int) ErrorCodes.Format));
                        }
                    } while (!done);

                    student = DatabaseHandler.IDMatchedStudentFromDatabase(studentEditByID);
                    if (student == null)
                    {
                        Console.WriteLine($"Student with ID {studentEditByID} not found.");
                    }
                    else
                    {
                        break; //Student was found; break while loop
                    }
                }

                return student;


            }

            List<Student> FindInputStudents()
            {
                List<Student> Students;
                while (true)
                {
                    Console.WriteLine("Name to search after (first or last name): ");
                    string nameSearch = Console.ReadLine();
                    if (nameSearch == "") //If search string is empty; make list of all students
                    {
                        Students = DatabaseHandler.GenerateStudentsList();
                    }
                    else //Else make list of students with names matching search string
                    {
                        Students = DatabaseHandler.NameMatchedStudentsFromDatabase(nameSearch);
                    }

                    if (Students.Count == 0)
                    {
                        Console.WriteLine($"No students with the name {nameSearch} was found. Please try again. Press enter to see all students.");
                    }
                    else
                    {
                        break; //List if not empty, break while loop
                    }
                }

                return Students;
            }
          
        }

    }
}

