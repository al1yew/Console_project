using ConsoleProject_1.Interfaces;
using ConsoleProject_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject_1.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departmentlist;
        public Department[] DepartmentList => _departmentlist;
        public HumanResourceManager()
        {
            _departmentlist = new Department[0];
        }

        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            Array.Resize(ref _departmentlist, _departmentlist.Length + 1);
            _departmentlist[_departmentlist.Length - 1] = new Department(name, workerlimit, salarylimit);
            return;
        }

        public void AddEmployee(string name, string surname, byte age, string position, double salary, string departmentname)
        {
            Department department = null;

            foreach (Department item in _departmentlist)
            {
                if (item.Name == departmentname.Trim().ToUpper())
                {
                    department = item;
                }
            }
            if (department != null)
            {
                Employee employee = new Employee(name, surname, age, position, salary, departmentname);
                department.AddEmployees(employee);
                return; // shto bi ashagidaki cw-ni yazmasin
            }
            Console.WriteLine("There is no Department equal to your input. Please try again.");
        }

        public void EditDepartment(string changedname, int workerlimit, double salarylimit)
        {
            foreach (Department department in DepartmentList)
            {
                if (department.Name == char.ToUpper(changedname[0]).ToString()) // eto tocno nepravilno ved otpravit tolko perviy char
                {
                    if (department.Employeelist.Length <= workerlimit)
                    {
                        department.WorkerLimit = workerlimit;
                    }
                    else
                    {
                        Console.WriteLine($"Your mentioned Limit is not appropriate, there is only {department.Employeelist.Length} places in department.\nPlease try again.");
                    }
                }

                department.SalaryLimit = salarylimit;
                department.Name = changedname;
                // burda nese olmalidi 

                foreach (Employee employee in department.Employeelist)
                {
                    employee.DepartmentName = department.Name; // burda da nese sehvdi char adlarin yazdirmir 
                }
                return;
            }
        }

        public void GetDepartmentWorkers(string name)
        {
            foreach (Department department in _departmentlist)
            {
                if (department.Name == name.Trim().ToUpper())
                {
                    foreach (Employee employee in department.Employeelist)
                    {
                        Console.WriteLine($"{employee}\n");
                    }
                }
            }
        }

        public void GetWorkersList()
        {
            foreach (Department department in _departmentlist)
            {
                Console.WriteLine(department.Employeelist);
            }
        }

        public void GetDepartments()
        {
            foreach (Department department in _departmentlist)
            {
                Console.WriteLine($"{department} Department");
            }
        }

        public void RemoveEmployee(string name, string position) // tut cheto ne to nado proverit
        {
            foreach (Department department in _departmentlist)
            {
                if (department.Name == name.Trim().ToUpper())
                {
                    for (int i = 0; i < department.Employeelist.Length; i++)
                    {
                        if (department.Employeelist[i].Name == name && department.Employeelist[i].Name == name)
                        {
                            department.Employeelist[i] = null;

                            department.Employeelist[i] = department.Employeelist[department.Employeelist.Length - 1];

                            Array.Resize(ref department.Employeelist, department.Employeelist.Length - 1);
                        }
                    }
                }
            }
            Console.WriteLine("There is no Employee that you are looking for Remove. Please try again.");
        }

        public void EditEmployee(string name, string surname, byte age, string position, double salary, string no)
        {
            foreach (Department department in _departmentlist)
            {
                if (department.Name == name.Trim().ToUpper())
                {
                    foreach (Employee employee in department.Employeelist)
                    {
                        if (employee.Name == name.Trim().ToUpper() && employee.Surname == surname.Trim().ToUpper())
                        {
                            employee.Name = name;
                            employee.Surname = surname;
                            employee.Age = age;
                            employee.Position = position;
                            employee.Salary = salary;
                        }
                    }
                }
            }
            Console.WriteLine("There is no employee that you have called. Please try again");
        }
    }
}