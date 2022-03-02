using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject_1.Models
{
    class Department
    {
        public string Name { get; set; }

        public int WorkerLimit { get; set; }

        public double SalaryLimit { get; set; }

        public Employee[] Employeelist;

        public void CalcSalaryAverage()
        {
            double salaryaverage = 0;
            int i = 0;
            foreach (Employee employee in Employeelist)
            {
                salaryaverage += Employeelist[i].Salary;
                i++;
                // mojno i cerez FOR napisat ya xz kak luchshe
            }
            double AverageofSalary = salaryaverage / WorkerLimit;
            Console.WriteLine($"The average salary in Department is {AverageofSalary}, " +
                $"which is aproximately {Math.Round(AverageofSalary)}");
        }





        public void AddEmployees(Employee employee)
        {
            if (Employeelist.Length < WorkerLimit)
            {
                Array.Resize(ref Employeelist, Employeelist.Length + 1);
                Employeelist[Employeelist.Length - 1] = employee;
            }
            Console.WriteLine($"There is no place for new employee. " +
                $"Please increase the capacity of group.");
        }






        public Department(string name, int workerlimit, double salarylimit)
        {
            Employeelist = new Employee[0];
            Name = name.Trim().ToUpper();
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }
    }
}
