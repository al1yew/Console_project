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
        public Department[] Departments => _departmentlist;
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

        public void EditDepartments(string name, int workerlimit, double salarylimit)
        {
            foreach (Department department in _departmentlist)
            {
                if (department.Name == name.Trim().ToString())
                {
                    department.WorkerLimit = workerlimit;
                }
                else
                {
                    Console.WriteLine("Your mentioned Limit is not appropriate. Please try again.");
                }

            }
        }

        public void GetDepartments()
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee(string no, string name, string surname, string position)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(string name, string surname, byte age, string position, double salary, string no)
        {
            throw new NotImplementedException();
        }
    }
}