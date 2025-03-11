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
            DatabaseHandler DbH = new DatabaseHandler();


            int val;
            while (true) 
            {
                ui.PrintMenu();
                val = int.Parse(Console.ReadLine());
            switch (val)
            {
                   
                case 1: //Add new 
                    DbH.AddStudent(ui.CreateStudent());
                    break;

                case 2: //Edit student
                        ui.EditStudent();
                        break;
                case 3: //List students
                        ui.PrintStudents(DbH);
                        break;
            }
        } 



            //Console.WriteLine(DbCtx.Students.FirstOrDefault<Student>().Name);

            //var std = (DbCtx.Students.Where(s => s.Name == "Mattias").FirstOrDefault<Student>());
            //std.City = "Stockholm";
            //DbCtx.SaveChanges();
            //UI ui = new UI();
            //ui.PrintMenu
        }

        
    }
}
