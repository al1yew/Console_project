using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject_1.Models
{
    class Department
    { 
        public Employee[] Employeelist;
        //public Department(){}
        private string _name;
        public string Name 
        {
            get => _name;
            set
            {
                while (value.Length < 2)
                {
                    Console.WriteLine($"{value} that you wrote is not appropriate. Department Name must contain at least 2 chars.\nPlease try again.");
                    value = Console.ReadLine();
                }
                _name = value.Trim().ToUpper();
            }
        }
        private int _workerlimit;
        public int WorkerLimit 
        {
            get => _workerlimit;
            set
            {
                while (value < 1)
                {
                    Console.WriteLine($"{value} that you wrote is not appropriate. Worker limit must be at least 1.\nPlease try again.");
                    int.TryParse(Console.ReadLine(), out value); 
                }
                _workerlimit = value;
            }
        }

        private double _salarylimit;
        public double SalaryLimit
        {
            get => _salarylimit;
            set
            {
                while (value < 250*WorkerLimit)
                {
                    Console.WriteLine($"Due to fact that 1 worker must have Salary limit at least 250 you need to " +
                        $"increase your input by {250 * WorkerLimit - value}.\nIt must be minimum {250 * WorkerLimit}");
                    double.TryParse(Console.ReadLine(), out value);
                }
                _salarylimit = value;
            }
        }

        public void AddEmployees(Employee employee)
        {
            if (Employeelist.Length < WorkerLimit && employee.Salary < SalaryLimit)
            {
                Array.Resize(ref Employeelist, Employeelist.Length + 1);
                Employeelist[Employeelist.Length - 1] = employee;
                return;
            }
            Console.WriteLine($"There is no place for new employee or Salary limit is full.\nPlease increase the capacity of Department or increase Salary limit.\nREMINDER!\nSalary limit is {SalaryLimit}\nWorker Limit is {WorkerLimit}");
        }

        public void CalcSalaryAverage()
        {
            double allsalary = 0;
            int i = 0;
            foreach (Employee employee in Employeelist)
            { 
                allsalary += Employeelist[i].Salary;
                i++;
            }
            double AverageofSalary = allsalary / Employeelist.Length;
            if (Employeelist.Length > 0)
            {
                Console.WriteLine($"The average salary is {AverageofSalary}, " +
                $"which is aproximately {Math.Round(AverageofSalary)}\n");
                return;
            }
            Console.WriteLine("There are no employees to calculate average salary\n");
            
        }

        public Department(string name, int workerlimit, double salarylimit)
        {
            Employeelist = new Employee[0];
            Name = name.Trim().ToUpper();
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }
        public override string ToString()
        {
            return $"Name of Department: {_name} Department\n" +
                $"Salary Limit for {_name} Department is: {_salarylimit}\n" +
                $"Worker Limit for {_name} Department is: {_workerlimit}\n" +
                $"Workers in it: {Employeelist.Length}\n";
        }
    }
}
