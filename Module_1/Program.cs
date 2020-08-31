using System;
using EmpoyeesLibrary;
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
                            Console.Clear();
                            Console.Write("Please enter the passport number of the employee: ");
                            int passport = int.Parse(Console.ReadLine());

                            Console.Write("Please enter the name of the employee: ");
                            string name = Console.ReadLine();

                            Console.Write("Please enter the age of the employee: ");
                            int age = int.Parse(Console.ReadLine());

                            Console.Write("Please enter the position of the employee: ");
                            string position = Console.ReadLine();

                            Console.Write("Please enter the name of the team: ");
                            string team = Console.ReadLine();

                            Console.Write("Please enter the number of hours worked: ");
                            double hoursWorked = double.Parse(Console.ReadLine());

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
                            foreach (var employee in EmployeeJournal.GetEmployees())
                            {
                                Console.WriteLine($"==========\n{employee}");
                            }

                        }
                        break;
                    case Menu.RemoveEmployee:
                        {
                            Console.Write("Please enter the index of the emplyoyee you would like to remove: ");
                            int index = int.Parse(Console.ReadLine());

                            EmployeeJournal.RemoveAt(index);
                        }
                        break;
                    case Menu.Exit:
                        {
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
            Exit = 4
        }



    }
}
