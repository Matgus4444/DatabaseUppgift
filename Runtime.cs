using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    internal class Runtime
    {

        public void Launch()
        {

            UI UserInterface = new UI();
            int menuChoise = 0;

            while (true)
            {
                UserInterface.PrintMenu(0);
                
                try
                {
                    menuChoise = int.Parse(Console.ReadLine());
                }
                catch (Exception) 
                {
                    Console.WriteLine("Only numbers.");
                }

                switch (menuChoise)
                {
                    case 1: //Add new student
                        UserInterface.CreateStudent();
                        break;

                    case 2: //Edit student
                        UserInterface.EditStudent();
                        break;
                    case 3: //List students
                        UserInterface.PrintStudents();
                        break;
                }
            }
        }

    }
}
