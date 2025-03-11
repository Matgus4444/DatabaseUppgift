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

            UI ui = new UI();
            int val;

            while (true)
            {
                ui.PrintMenu();
                
                val = int.Parse(Console.ReadLine());

                switch (val)
                {
                    case 1: //Add new student
                        ui.CreateStudent();
                        break;

                    case 2: //Edit student
                        ui.EditStudent();
                        break;
                    case 3: //List students
                        ui.PrintStudents();
                        break;
                }
            }
        }

    }
}
