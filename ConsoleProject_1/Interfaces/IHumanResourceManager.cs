using ConsoleProject_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject_1.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }

        void AddDepartment(string name, int workerlimit, double salarylimit);
        void GetDepartments();
        void GetDepartmentWorkers(string name);
        void GetWorkersList();
        void EditDepartment(string name, int workerlimit, double salarylimit);
        void AddEmployee(string name, string surname, byte age, string position, double salary, string departmentname);
        void RemoveEmployee(string no, string name, string surname, string position);
        void EditEmployee(string name, string surname, byte age, string position, double salary, string no); //kak izmenit nomer on je sam generiruyetsa
    }
}
