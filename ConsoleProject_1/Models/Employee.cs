using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject_1.Models
{
    class Employee
    {
        private static int _num = 1000; // dla ego Nomera
        public string No;

        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public string Position { get; set; }

        private double _salary;
        public double Salary
        {
            get => _salary;
            set
            {
                while (value != _salary)
                {
                    if (Salary >= 250)
                    {
                        _salary = value;
                    }
                    Console.WriteLine($"Salary must be at least 250 azn. You need to add {250 - value} azn"); // eto nash else
                    double.TryParse(Console.ReadLine(), out value);
                }
            }
        }

        public string DepartmentName { get; set; }
        public Employee(string name, string surname, byte age, string position, double salary,string departmentname)
        {
            Name = name.Trim().ToUpper();   // nado sdelat tak shto bi ubral white space i sdelal ima familie s bolshoy bukvi perviy indeks
            Surname = surname.Trim().ToUpper();
            Age = age;
            Position = position;
            Salary = salary;
            DepartmentName = departmentname;
            _num++;
            No = $"{departmentname[0].ToString().ToUpper()}{departmentname[1].ToString().ToUpper()}{_num}";
        }
        public override string ToString()
        {
            return $"Worker:\n" +
                $"Full Name: {Name} {Surname}\n" +
                $"Age: {Age}" +
                $"Position: {Position}\n" +
                $"Salary: {Salary}\n" +
                $"Department Name: {DepartmentName}\n" +
                $"No: {No}";
        }
    }
}
