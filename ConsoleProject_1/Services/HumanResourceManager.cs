using ConsoleProject_1.Interfaces;
using ConsoleProject_1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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

        public void AddDepartment(string name, byte workerlimit, double salarylimit)
        {
            Array.Resize(ref _departmentlist, _departmentlist.Length + 1);
            _departmentlist[_departmentlist.Length - 1] = new Department(name, workerlimit, salarylimit);
            return;
        }

        public void AddEmployee(string name, string surname, byte age, string position, double salary, string departmentname)
        {
            Department department = null;

            foreach (Department item in DepartmentList)
            {
                if (item.Name.Trim().ToUpper() != departmentname.Trim().ToUpper())
                {
                    Console.WriteLine($"Declared {departmentname.Trim().ToUpper()} Department has not been found.\nPlease try again.");
                    departmentname = Console.ReadLine();
                    while (!Regex.IsMatch(departmentname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(departmentname, @"^\S+(?: \S+)*$"))
                    {
                        Console.WriteLine($"There is no Department called {departmentname.Trim().ToUpper()} in Departments list.");
                        departmentname = Console.ReadLine();
                    }
                }
                foreach (Department department1 in _departmentlist)
                {
                    if (department1.Name == departmentname.Trim().ToUpper())
                    {
                        department = department1;
                    }
                }
                if (department != null)
                {
                    Employee employee = new Employee(name, surname, age, position, salary, departmentname);
                    department.AddEmployees(employee);
                    return;
                }
                Console.WriteLine("There is no Department equal to your input. Please try again.");
            }
        }

        public void EditDepartment(string inputdepname, string changedname, int workerlimit, double salarylimit)
        {
            foreach (Department department in DepartmentList)
            {
                if (department.Name != inputdepname.Trim().ToUpper())
                {
                    Console.WriteLine("\nThere is no department that you called.\nPlease, try again.\n");
                    return;
                }

                department.Name = changedname.Trim().ToUpper();
                department.WorkerLimit = workerlimit;
                department.SalaryLimit = salarylimit;

                foreach (Employee employee in department.Employeelist)
                {
                    employee.DepartmentName = department.Name;
                    employee.No = employee.No.Replace(employee.No[0], char.ToUpper(changedname.ToString()[0]));
                    employee.No = employee.No.Replace(employee.No[1], char.ToUpper(changedname.ToString()[1]));
                }
                return;
            }
        }

        public void RemoveEmployee(string no, string name, string surname) // tut cheto ne to nado proverit
        {
            foreach (Department department in _departmentlist)
            {
                if (department.Name == no.Trim().ToUpper())
                {
                    for (int i = 0; i < department.Employeelist.Length; i++)
                    {
                        if (department.Employeelist[i].Name == no && department.Employeelist[i].Name == no)
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

        public void EditEmployee(string name, string surname, byte age, string position, double salary, string no, string departmentname)
        {
            foreach (Department department in _departmentlist)
            {
                if (department.Name == departmentname.Trim().ToUpper())
                {
                    foreach (Employee employee in department.Employeelist)
                    {
                        if (employee.Name == name.Trim().ToUpper() && employee.Surname == surname.Trim().ToUpper() && employee.No == no.Trim().ToUpper())
                        {
                            employee.Name = name;
                            employee.Surname = surname;
                            employee.Age = age;
                            employee.Position = position;
                            employee.Salary = salary;
                            employee.DepartmentName = departmentname;
                            // qaldi bidene No su onu da baxariq
                        }
                    }
                }
            }
            Console.WriteLine("There is no employee that you have called. Please try again");
        }
    }
}