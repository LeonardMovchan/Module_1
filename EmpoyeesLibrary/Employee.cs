using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace EmpoyeesLibrary
{
    public class EmployeeJournal
    {
        private static List<Employee> _employees = new List<Employee>();

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public static Employee[] GetEmployees()
        {
            return _employees.ToArray();
        }

        public static void RemoveAt(int index)
        {
            _employees.RemoveAt(index);
        }


    }
    public class Employee
    {
        public Employee(int passport, string name, int age, string position, string team, double hoursworked)
        {
            this.Passport = passport;
            this.Name = name;
            this.Age = age;
            this.Position = position;
            this.Team = team;
            this.HoursWorked = hoursworked;
        }

        public int Passport { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }        
        public double HoursWorked { get; set;}


        public override string ToString()
        {
            return $"Passport: {this.Passport}\nName: {this.Name}\nAge: {this.Age}\nPosition: {this.Position}\nTeam: {this.Team}\nHours Worked: {this.HoursWorked}";
        }

    }
}
