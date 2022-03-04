using ConsoleProject_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject_1.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] DepartmentList { get; }

        void AddDepartment(string name, int workerlimit, double salarylimit);
        void EditDepartment(string changedname, int workerlimit, double salarylimit);
        void AddEmployee(string name, string surname, byte age, string position, double salary, string departmentname);
        void RemoveEmployee(string no, string position);
        void EditEmployee(string name, string surname, byte age, string position, double salary, string no); //kak izmenit nomer on je sam generiruyetsa
    }
}
