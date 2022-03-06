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
                return;
            }
            Console.WriteLine("There is no Department equal to your input.\nRefresh page and try again.\nDo not forget to glance on list of departments.");
        }

        public void EditDepartment(string inputdepname, string changedname, int workerlimit, double salarylimit)
        {
            foreach (Department department in DepartmentList)
            {
                if (department.Name == inputdepname.Trim().ToUpper())
                {
                    department.Name = changedname.Trim().ToUpper();
                    department.WorkerLimit = workerlimit;
                    department.SalaryLimit = salarylimit;

                    foreach (Employee employee in department.Employeelist)
                    {
                        employee.No = employee.No.Replace(employee.No[0], char.ToUpper(changedname.ToString()[0]));
                        employee.No = employee.No.Replace(employee.No[1], char.ToUpper(changedname.ToString()[1]));
                    }
                    return;
                }
            }
            Console.WriteLine("\nThere is no department that you called.\nPlease, try again.\n");
        }

        public void RemoveEmployee(string no, string inputdepname)
        {
            foreach (Department department in _departmentlist)
            {
                if (department.Name == inputdepname.Trim().ToUpper())
                {
                    for (int i = 0; i < department.Employeelist.Length; i++)
                    {
                        if (department.Employeelist[i].No == no.Trim().ToUpper())
                        {
                            department.Employeelist[i] = null;

                            department.Employeelist[i] = department.Employeelist[department.Employeelist.Length - 1];

                            Array.Resize(ref department.Employeelist, department.Employeelist.Length - 1);

                            return;
                        }
                        else
                        {
                            Console.WriteLine("There is no Employee personal NO that you are looking for Remove. Please try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There is no Department that you are looking for.\nRefresh page and try again.\nDo not forget to glance on list of departments.");
                }
            }
        }

        public void EditEmployee(string name, string surname, byte age, string position, double salary, string no, string departmentname)
        {
            foreach (Department department in _departmentlist)
            {
                if (department.Name == departmentname.Trim().ToUpper())
                {
                    foreach (Employee employee in department.Employeelist)
                    {
                        if (employee.No.Trim().ToUpper() == no.Trim().ToUpper())
                        {
                            employee.Name = name;
                            employee.Surname = surname;
                            employee.Age = age;
                            employee.Position = position;
                            employee.Salary = salary;
                            employee.DepartmentName = departmentname;
                            //mojno i bez etoqo
                            employee.No = employee.No.Replace(employee.No[0], char.ToUpper(departmentname.ToString()[0]));
                            employee.No = employee.No.Replace(employee.No[1], char.ToUpper(departmentname.ToString()[1]));
                        }
                        else
                        {
                            Console.WriteLine("Employee's personal NO is written false.");
                        }
                    }
                }
            }
            Console.WriteLine($"There is no {departmentname} you called, or there is no employees in it.");
        }

        public void GetDepartmentWorkers(string departmentname)
        {
            foreach (Department department in DepartmentList)
            {
                if (department.Name.Trim().ToUpper() == departmentname.Trim().ToUpper())
                {
                    if (department.Employeelist.Length > 0)
                    {
                        foreach (Employee employee in department.Employeelist)
                        {
                            Console.WriteLine(employee);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There is no Employees in {departmentname.ToUpper()} Department. Please add some");
                        return;
                    }
                }
            }
            Console.WriteLine("Written Department name is declared false");
            return;
        }
    }
}