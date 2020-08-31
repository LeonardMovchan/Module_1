using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("=======MENU=======");
                Console.WriteLine("1. Add new employee");
                Console.WriteLine("2. Check all employees");
                Console.WriteLine("3. Remove employee");
                Console.WriteLine("4. Exit");

                Menu menu = (Menu)int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case Menu.AddNewEmployee:
                        {

                        }break;
                    case Menu.CheckEmployees:
                        {

                        }break;
                    case Menu.RemoveEmployee:
                        {

                        }break;
                    case Menu.Exit:
                    {

                    }break;

                    default:
                        {
                            Console.WriteLine("There is no such command");
                        }break;
                }

            } while (true);
        }

        enum Menu
        {
            NoItem = 0,
            AddNewEmployee = 1,
            CheckEmployees = 2,
            RemoveEmployee = 3,
            Exit = 4
        }
            

        
    }
}
