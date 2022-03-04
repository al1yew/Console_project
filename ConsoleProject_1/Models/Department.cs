using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject_1.Models
{
    class Department
    {

        public Employee[] Employeelist;


        private string _name;
        public string Name 
        {
            get => _name;
            set
            {
                while (value.Length < 2)
                {
                    Console.WriteLine($"{value} that you wrote is not appropriate. Department Name must contain at least 2 chars. Please try again.");
                    value = Console.ReadLine();
                }
                // while right olsa assign edir // while sehf hali yoxlamalidi bele ki tekrar console readline istesin
                _name = value;
            }
        }
        private int _workerlimit;
        public int WorkerLimit 
        {
            get => _workerlimit;
            set
            {
                while (value < 2)
                {
                    Console.WriteLine($"{value} that you wrote is not appropriate. Position must contain at least 2 chars. Please try again.");
                    int.TryParse(Console.ReadLine(), out value); // krasota bir setrlik
                }
                // while right olsa assign edir // while sehf hali yoxlamalidi bele ki tekrar console readline istesin
                _workerlimit = value;
            }
        }
        private double _salarylimit;

        public double SalaryLimit // esli pri proverke vvodit snachala bukvu pootom cisla on grabotaet s errorom
        {
            get => _salarylimit;
            set
            {
                while (value < 250*WorkerLimit)
                {
                    Console.WriteLine($"Due to fact that 1 worker must have Salary limit at least 250 you need to " +
                        $"increase your input by {250 * WorkerLimit - value}");
                    double.TryParse(Console.ReadLine(), out value);
                }
                value = _salarylimit;
            }
        }

        public void AddEmployees(Employee employee)
        {
            if (Employeelist.Length < WorkerLimit)
            {// arraya yigmag lazimdi
                Array.Resize(ref Employeelist, Employeelist.Length + 1);
                Employeelist[Employeelist.Length - 1] = employee;
            }
            Console.WriteLine($"There is no place for new employee. Please increase the capacity of Department.");
        }

        public void CalcSalaryAverage()
        {
            double allsalary = 0;
            int i = 0;
            foreach (Employee employee in Employeelist)
            {
                allsalary += Employeelist[i].Salary;
                i++;
                // mojno i cerez FOR napisat ya xz kak luchshe
            }
            double AverageofSalary = allsalary / WorkerLimit;
            Console.WriteLine($"The average salary in Department is {AverageofSalary}, " +
                $"which is aproximately {Math.Round(AverageofSalary)}");
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
            return $"Name of Department: {_name}\n" +
                $"Salary Limit for {_name} Department is {_salarylimit}\n" +
                $"Worker Limit for {_name} Department is {_workerlimit}";
        }
    }
}
