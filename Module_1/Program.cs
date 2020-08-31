using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using EmpoyeesLibrary;
namespace Module_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            EmployeeJournal.OpenFile();
            do
            {
                Console.Clear();
                Console.WriteLine("=======MENU=======");
                Console.WriteLine("1. Add new employee");
                Console.WriteLine("2. Check all employees");
                Console.WriteLine("3. Remove employee");
                Console.WriteLine("4. Total hours worked by the team");
                Console.WriteLine("5. Exit");

                Menu menu = (Menu)InputIntValidation();

                switch (menu)
                {
                    case Menu.AddNewEmployee:
                        {
                            Console.Clear();
                            Console.Write("Please enter the passport number of the employee: ");
                            int passport = InputIntValidation();

                            Console.Write("Please enter the name of the employee: ");
                            string name = Console.ReadLine();

                            Console.Write("Please enter the age of the employee: ");
                            int age = InputIntValidation();

                            Console.Write("Please enter the position of the employee: ");
                            string position = Console.ReadLine();

                            Console.Write("Please enter the name of the team: ");
                            string team = Console.ReadLine();

                            Console.Write("Please enter the number of hours worked: ");
                            double hoursWorked = InputDoubleValidation();

                            Employee employee = new Employee
                                (
                                passport: passport,
                                name: name,
                                age: age,
                                position: position,
                                team: team,
                                hoursWorked: hoursWorked
                                );

                            EmployeeJournal.Add(employee);

                        }
                        break;
                    case Menu.CheckEmployees:
                        {
                            Console.Clear();
                            foreach (var employee in EmployeeJournal.GetEmployees())
                            {
                                
                                Console.WriteLine($"==========\n{employee}");
                                
                            }
                            Console.ReadKey();
                        }
                        break;
                    case Menu.RemoveEmployee:
                        {
                            Console.Write("Please enter the index of the emplyoyee you would like to remove: ");
                            InputIndexValidation();
                            Console.ReadKey();
                        
                        }
                        break;
                    case Menu.TeamHoursWorked:
                        {
                            Console.Write("Please enter the name of the team: ");
                            string team = Console.ReadLine();
                            double teamHoursWorked = EmployeeJournal.TeamHours(team);

                            Console.WriteLine($"The total hours worked by team {team}: {teamHoursWorked}");

                            Console.ReadKey();

                        }break;

                    case Menu.Exit:
                        {
                            EmployeeJournal.SaveToFile();
                            return;
                        }
                        
                    default:
                        {
                            Console.WriteLine("There is no such command");
                        }
                        break;
                }

            } while (true);
        }

        enum Menu
        {
            NoItem = 0,
            AddNewEmployee = 1,
            CheckEmployees = 2,
            RemoveEmployee = 3,
            TeamHoursWorked = 4,
            Exit = 5
        }

        public static int InputIntValidation()
            
        {
            int value;

            while(!int.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.WriteLine("Please enter a valid positive number");
                
            }
            return value;
        }
        public static double InputDoubleValidation()
        {
            double value;

            while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.WriteLine("Please enter a valid positive number");

            }
            return value;
        }

        public static int InputIndexValidation()

        {
            int value;

            while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.WriteLine("Please enter a valid positive number");
           
            }
          
            if (value < EmployeeJournal.GetEmployees().Length)
            {
                EmployeeJournal.RemoveAt(value);
                Console.WriteLine($"The employee on index {value} was succesffully removed from the list");
                Console.WriteLine();
            }
            else Console.WriteLine("There is no such employee");

            return value;
        }

    }
}
