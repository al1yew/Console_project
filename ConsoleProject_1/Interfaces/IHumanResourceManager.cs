using ConsoleProject_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject_1.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] DepartmentList { get; }
        
        void AddDepartment(string name, byte workerlimit, double salarylimit);
        void EditDepartment(string inputdepname, string changedname, int workerlimit, double salarylimit);
        void AddEmployee(string name, string surname, byte age, string position, double salary, string departmentname);
        void RemoveEmployee(string no, string inputdepname);
        void EditEmployee(string name, string surname, byte age, string position, double salary, string no, string departmentname); //kak izmenit nomer on je sam generiruyetsa
        void GetDepartmentWorkers(string departmentname);
    }
}
