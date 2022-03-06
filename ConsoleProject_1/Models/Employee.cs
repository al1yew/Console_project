using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject_1.Models
{
    class Employee
    {
        private static int _num = 1000;
        public string No;

        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public string DepartmentName { get; set; }

        private string _position;
        public string Position 
        {
            get => _position;
            set 
            {
                while (value.Length < 2)
                {
                    Console.WriteLine($"{value} that you wrote is not appropriate. Position must contain at least 2 chars. Please try again.");
                    value = Console.ReadLine();
                }
                _position = value;
            }
        }

        private double _salary;
        public double Salary
        {
            get => _salary;
            set
            {
                while (value < 250)
                { 
                    Console.WriteLine($"Salary must be at least 250 azn. You need to add {250 - value} azn");
                    double.TryParse(Console.ReadLine(), out value);
                }
                _salary = value;
            }
        }

        public Employee(string name, string surname, byte age, string position, double salary, string departmentname)
        {
            Name = name.Trim().ToUpper();
            Surname = surname.Trim().ToUpper();
            Age = age;
            Position = position;
            Salary = salary;
            DepartmentName = departmentname;
            _num++;
            No = $"{char.ToUpper(DepartmentName.ToString()[0])}{DepartmentName[1].ToString().ToUpper()}{_num}";
        }
        public override string ToString()
        {
            return $"Worker:\n" +
                $"Full Name: {Name.ToUpper()} {Surname.ToUpper()}\n" +
                $"Age: {Age}\n" +
                $"Position: {_position.Trim().ToUpper()}\n" +
                $"Salary: {_salary}\n" +
                $"Department Name: {DepartmentName.Trim().ToUpper()}\n" +
                $"No: {No}\n";
        }
    }
}
