using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EmpoyeesLibrary
{

    public class EmployeeJournal
    {

        public static List<Employee> _employees = new List<Employee>();

        public static void Add(Employee employee)
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

        public static double TeamHours(string team)
        {
            double teamHoursWorked = 0;
            for (int i = 0; i < _employees.Count; i++)
            {
                if (_employees[i].Team == team)
                {
                    teamHoursWorked += _employees[i].HoursWorked;
                }

            }
            return teamHoursWorked;
        }

        public static void SaveToFile()
        {
            Stream stream = File.Open(Environment.CurrentDirectory + "\\text.xml", FileMode.Create);

            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Employee>));
            xmlSer.Serialize(stream, _employees);
            stream.Close();
        }

        public static void OpenFile()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\text.xml"))
            {
                Stream stream = File.Open(Environment.CurrentDirectory + "\\text.xml", FileMode.Open);

                XmlSerializer xmlSer = new XmlSerializer(typeof(List<Employee>));

                _employees = (List<Employee>)xmlSer.Deserialize(stream);
                stream.Close();
            }
        }
    }

    [Serializable]
    public class Employee
    {
        public Employee() { }
        public Employee(int passport, string name, int age, string position, string team, double hoursWorked)
        {
            this.Passport = passport;
            this.Name = name;
            this.Age = age;
            this.Position = position;
            this.Team = team;
            this.HoursWorked = hoursWorked;
        }

        public int Passport { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public double HoursWorked { get; set; }


        public override string ToString()
        {
            return $"Passport: {this.Passport}\nName: {this.Name}\nAge: {this.Age}\nPosition: {this.Position}\nTeam: {this.Team}\nHours Worked: {this.HoursWorked}";
        }

    }
}
