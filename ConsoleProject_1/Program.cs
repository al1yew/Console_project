using ConsoleProject_1.Services;
using System;
using ConsoleProject_1.Interfaces;
using ConsoleProject_1.Models;
using System.Text.RegularExpressions;

namespace ConsoleProject_1
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();

            do
            {
                Console.WriteLine($"\n===== Hello dear user =====\n" + "\n" +
                    $"1. -- Show all departments\n" +
                    $"2. -- Add department\n" +
                    $"3. -- Edit department\n" +
                    $"4. -- Get department workers\n" +
                    $"5. -- Get Workers\n" +
                    $"6. -- Add employee\n" +
                    $"7. -- Edit employee\n" +
                    $"8. -- Remove employee\n" +
                    $"9. -- Calculate Average Salary of Departments Workers\n" +
                    $"10.-- Exit\n" +
                    $"+_+_+_+_+_+_+_+_+_+_+_+_+ ");

                string userchoice = Console.ReadLine();
                byte userchoicenum;

                while (!byte.TryParse(userchoice, out userchoicenum) || userchoicenum < 1 || userchoicenum > 11)
                {
                    Console.WriteLine("\nYou need to choose numbers from 1 to 9 without using any other symbols.\nTry again\n");
                    userchoice = Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine($"-- We are preparing the process...");
                switch (userchoicenum)
                {
                    case 1:
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 2:
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        EditDepartment(ref humanResourceManager);
                        break;
                    case 4:
                        GetDepartmentWorkers(ref humanResourceManager);
                        break;
                    case 5:
                        GetWorkersList(ref humanResourceManager);
                        break;
                    case 6:
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 7:
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 8:
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    case 9:
                        CalcSalaryAverage(ref humanResourceManager);
                        break;
                    case 10:
                        Console.Clear();
                        Console.WriteLine("Thanks for visiting. All the best.");
                        return;
                }

            } while (true);
        }

        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.DepartmentList.Length > 0)
            {
                Console.WriteLine($"Welcome. There are {humanResourceManager.DepartmentList.Length} Departments.");
                Console.WriteLine("\nDepartments list:\n");
                foreach (Department department in humanResourceManager.DepartmentList)
                {
                    Console.WriteLine(department);
                    department.CalcSalaryAverage();
                }
            }
            else
            {
                Console.WriteLine("\nSorry but there are no Departments in system. Try to add some.\n");
                return;
            }
        }

        static void GetDepartmentWorkers(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Welcome. Here you can get workers from department name of which you write.");
            if (humanResourceManager.DepartmentList.Length > 0)
            {
                Console.WriteLine($"There are {humanResourceManager.DepartmentList.Length} Departments, choose the name of one of them to get workers it contains:\n");
                foreach (Department department in humanResourceManager.DepartmentList)
                {
                    Console.WriteLine(department.Name);
                }
            }
            else
            {
                Console.WriteLine($"There are no Departments. Please add them first of all.");
                return;
            }

            Console.WriteLine("Write down the name of department workers of which you want to get:");
            string departmentname = Console.ReadLine();

            while (!Regex.IsMatch(departmentname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(departmentname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"There is no Department called {departmentname.Trim().ToUpper()} in Departments list.\nUse only letters..");
                departmentname = Console.ReadLine();
            }

            humanResourceManager.GetDepartmentWorkers(departmentname);
        }

        static void GetWorkersList(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Welcome to Workers List.");
            if (humanResourceManager.DepartmentList.Length > 0)
            {
                foreach (Department department in humanResourceManager.DepartmentList)
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
                        Console.WriteLine($"There are no employees in system. Please add them first of all.");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine($"There are no Departments. Please add them first of all.");
                return;
            }
        }

        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("\nWelcome to Department creator.\nPlease write down name of Department that you are going to add:");
            string name = Console.ReadLine();

            while (!Regex.IsMatch(name, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(name, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven name {name} for Department is not appropriate.\n1.It must contain at least 2 elements.\nIt MUST NOT contain something other than letters or whitespaces (only between words).");
                name = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the worker limit that you are going to implement");
            string workerlimitstr = Console.ReadLine();
            byte workerlimitint;

            while (!byte.TryParse(workerlimitstr, out workerlimitint) || workerlimitint < 1 || workerlimitint > 50)
            {
                Console.WriteLine("\nThe worker limit is not appropriate.\nYou need to use only numbers from 1 to 50.\nPlease try again:");
                workerlimitstr = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the salary limit that you are going to implement");
            string salarylimitstr = Console.ReadLine();

            while (!Regex.IsMatch(salarylimitstr, @"^\d+$"))
            {
                Console.WriteLine($"\nThe salary limit is not appropriate.\n1.Salary limit must be written as numbers.\n2.Salary limit should be minimum {workerlimitint * 250} for your Worker Limit.\nTry again.");
                salarylimitstr = Console.ReadLine();
            }
     
            double salarylimitint = double.Parse(salarylimitstr);

            humanResourceManager.AddDepartment(name, workerlimitint, salarylimitint);

            Console.WriteLine("BYE!");
        }

        static void EditDepartment(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.DepartmentList.Length > 0)
            {
                if (humanResourceManager.DepartmentList.Length == 1)
                {
                    Console.WriteLine($"There is only one Department:");
                }
                else
                {
                    Console.WriteLine($"There are {humanResourceManager.DepartmentList.Length} Departments, choose the name of one that you want to edit:");
                }
                foreach (Department department in humanResourceManager.DepartmentList)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine($"\nThere are no Departments. Please add them first of all.");
                return;
            }
            Console.WriteLine("Welcome to department editor.\n\nWrite down the name of department that you want to edit:\n");
            string inputdepname = Console.ReadLine();

            while (!Regex.IsMatch(inputdepname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(inputdepname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"There is no Department called {inputdepname.Trim().ToUpper()} in Departments list. Use only Letters");  
                inputdepname = Console.ReadLine();
            }

            Console.WriteLine("\nPlease enter the new name:\n");
            string changedname = Console.ReadLine();

            while (!Regex.IsMatch(changedname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(changedname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nDeclared {changedname.Trim().ToUpper()} cannot be assigned as Department name.\n1.Please use ONLY letters.\n2.Please write at least 2 characters.\n");
                changedname = Console.ReadLine();
            }

            Console.WriteLine($"\nNow set new worker limit in new created {changedname.Trim().ToUpper()} department\n");

            string workerlimitstr = Console.ReadLine();
            int workerlimit;

            while (!int.TryParse(workerlimitstr, out workerlimit) || workerlimit < 1 || workerlimit > 50)
            {
                Console.WriteLine("\nWorker limit can be declared only as numbers from 1 to 50.\nTry again:");
                workerlimitstr = Console.ReadLine();
            }

            Console.WriteLine($"\nNow set new salary limit in new created {changedname.Trim().ToUpper()} department.\n");
            string salarylimitstr = Console.ReadLine();
            double salarylimit;
            
            while (!double.TryParse(salarylimitstr, out salarylimit))
            {
                Console.WriteLine($"\nSalary limit can be declared only as numbers and must be minimum {workerlimit * 250}.\nTry again:");
                salarylimitstr = Console.ReadLine();
            }
            humanResourceManager.EditDepartment(inputdepname, changedname, workerlimit, salarylimit);
        }

        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.DepartmentList.Length > 0)
            {
                if (humanResourceManager.DepartmentList.Length == 1)
                {
                    Console.WriteLine($"There is only one Department.");
                }
                else
                {
                    Console.WriteLine($"There are {humanResourceManager.DepartmentList.Length} Departments, choose the name of one that you want to edit:");
                }
                foreach (Department department in humanResourceManager.DepartmentList)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine($"\nThere are no Departments. Please add them first of all.");
                return;
            }
            Console.WriteLine("Welcome to employee adding program.");
            Console.WriteLine("\nWrite employee's department name:");
            string departmentname = Console.ReadLine();

            while (!Regex.IsMatch(departmentname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(departmentname, @"^\S+(?: \S+)*$") )
            {
                Console.WriteLine($"\nDeclared {departmentname.Trim().ToUpper()} cannot be assigned as Department name.\n1.Please use ONLY letters.\nPlease write at least 2 characters.");
                departmentname = Console.ReadLine();
            }

            Console.WriteLine("Good!\nNow write employee Name:");
            string name = Console.ReadLine();

            while (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine($"{name.Trim().ToUpper()} name is written in a wrong way. Use only letters.");
                name = Console.ReadLine();
            }

            Console.WriteLine("Good!\nNow write employee Surname:");
            string surname = Console.ReadLine();

            while (!Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine($"{surname.Trim().ToUpper()} surname is written in a wrong way. Use only letters.\nTry again:");
                surname = Console.ReadLine();
            }

            Console.WriteLine("Good!\nWrite employee's Age:");
            string agestr = Console.ReadLine();
            byte age = 0;

            while (!byte.TryParse(agestr, out age) || age < 18 || age > 65)
            {
                Console.WriteLine("Age you wrote is not appropriate.\n1. It must be between 18 and 65.\n2. It must contain only numbers.");
                agestr = Console.ReadLine();
                byte.TryParse(agestr, out age);
            }

            Console.WriteLine("Write employee's position:");
            string position = Console.ReadLine();

            while (!Regex.IsMatch(position, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(position, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"{ position} position is written in a wrong way.\n1. It must contain only Letters.\n2. It must contain at least 2 symbols.");
                position = Console.ReadLine();
            }

            Console.WriteLine("Good!\nWrite employee's salary:");
            string salarystr = Console.ReadLine();
            double salary;

            while (!double.TryParse(salarystr, out salary))
            {
                Console.WriteLine($"Salary {salary} you wrote is not appropriate.\n1. It must contain only Numbers.\n2.It must be minimum 250.");
                salarystr = Console.ReadLine();
                double.TryParse(salarystr, out salary);
            }
            
            
            humanResourceManager.AddEmployee(name, surname, age, position, salary, departmentname);
            Console.WriteLine("\nBYE!");
        }

        static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Welcome to Employee editor.");

            if (humanResourceManager.DepartmentList.Length <= 0)
            {
                Console.WriteLine($"\nThere are no Departments. Please add them first of all.");
                return;
            }
            Console.WriteLine($"\nThere are {humanResourceManager.DepartmentList.Length} Departments:");

            foreach (Department department in humanResourceManager.DepartmentList)
            {
                Console.WriteLine($"Department name: {department.Name}");
            }

            foreach (Department department in humanResourceManager.DepartmentList)
            {
                if (department.Employeelist.Length <= 0)
                {
                    Console.WriteLine($"There are no employees in {department.Name} to edit.\nPlease add them there first of all");
                }
                foreach (Employee employee in department.Employeelist)
                {
                    Console.WriteLine($"Employee personal No: {employee.No}");
                }
            }

            Console.WriteLine("Write employee's department name from the list:");
            string departmentname = Console.ReadLine();

            while (!Regex.IsMatch(departmentname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(departmentname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nDeclared {departmentname} cannot be assigned as Department name.\n1.Please use ONLY letters.\nPlease write at least 2 characters.");
                departmentname = Console.ReadLine();
            }
            //stackda chrome zakladki
            bool checkdep = true;
            bool checkemplo = true;
            while (checkdep)
            {
                foreach (Department department in humanResourceManager.DepartmentList)
                {
                    if (department.Name.ToUpper() == departmentname.ToUpper())
                    {
                        foreach (Employee employee in department.Employeelist)
                        {
                            if (employee != null)
                            {
                                checkemplo = false;
                            }
                        }
                        if (checkemplo == true)
                        {
                            Console.WriteLine($"There is no employees in {department.Name} Department.");
                            return;
                        }
                        checkdep = false;
                    }
                }
                if (checkdep == true)
                {
                    Console.WriteLine($"There is no {departmentname} Department in our list. Please try again.");
                    departmentname = Console.ReadLine();
                }
            }

            Console.WriteLine("Write down the employee's NO:");
            string no = Console.ReadLine();

            while (!Regex.IsMatch(no, "^.*[a-zA-Z]{2}[0-9]{4}.*$"))
            {
                Console.WriteLine($"There is no Employee with {no} No in Department's Employees list.\nThe No of employee must contain 2 letters and 4 numbers.\nTry again:");
                no = Console.ReadLine();
            }

            Console.WriteLine("\nNow write employee's new Name:");
            string name = Console.ReadLine();

            while (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine($"{name} name is written in a wrong way. Use only letters.");
                name = Console.ReadLine();
            }

            Console.WriteLine("\nNow write employee's new Surname:");
            string surname = Console.ReadLine();

            while (!Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine($"{surname} surname is written in a wrong way. Use only letters.\nTry again:");
                surname = Console.ReadLine();
            }

            Console.WriteLine("Good!\nWrite employee's new Age:");
            string agestr = Console.ReadLine();
            byte age = 0;

            while (!byte.TryParse(agestr, out age) || age < 18 || age > 65)
            {
                Console.WriteLine("Age you wrote is not appropriate.\n1. It must be between 18 and 65.\n2. It must contain only numbers.");
                agestr = Console.ReadLine();
                byte.TryParse(agestr, out age);
            }

            Console.WriteLine("Write employee's new position:");
            string position = Console.ReadLine();

            while (!Regex.IsMatch(name, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(name, @"^\S+(?: \S+)*$") )
            {
                Console.WriteLine($"{position} position is written in a wrong way.\n1. It must contain only Letters.\n2. It must contain at least 2 symbols.");
                position = Console.ReadLine();
            }

            Console.WriteLine("Write employee's new salary:");
            string salarystr = Console.ReadLine();
            double salary;
            while (!double.TryParse(salarystr, out salary))
            {
                Console.WriteLine($"Salary {salary} you wrote is not appropriate.\n1. It must contain only Numbers.\n2.It must be minimum 250.");
                salarystr = Console.ReadLine();
                double.TryParse(salarystr, out salary);
            }

            Console.WriteLine("BYE!");

            humanResourceManager.EditEmployee(name, surname, age, position, salary, no.Trim().ToUpper(), departmentname.Trim().ToUpper());
        }

        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Welcome to employee remover.");

            if (humanResourceManager.DepartmentList.Length <= 0)
            {
                Console.WriteLine($"\nThere are no Departments. Please add them first of all.");
                return;
            }
            Console.WriteLine($"\nThere are {humanResourceManager.DepartmentList.Length} Departments:");

            foreach (Department department in humanResourceManager.DepartmentList)
            {
                Console.WriteLine($"Department name: {department.Name}");
            }

            foreach (Department department in humanResourceManager.DepartmentList)
            {
                if (department.Employeelist.Length <= 0)
                {
                    Console.WriteLine($"There are no employees in {department.Name} to edit.\nPlease add them there first of all");
                }
                foreach (Employee employee in department.Employeelist)
                {
                    Console.WriteLine($"Employee personal No: {employee.No}");
                }
            }

            Console.WriteLine("Write employee's department name from the list:");
            string departmentname = Console.ReadLine();

            while (!Regex.IsMatch(departmentname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(departmentname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nDeclared {departmentname} cannot be assigned as Department name.\n1.Please use ONLY letters.\nPlease write at least 2 characters.");
                departmentname = Console.ReadLine();
            }
            //stackda chrome zakladki
            bool checkdep = true;
            bool checkemplo = true;
            while (checkdep)
            {
                foreach (Department department in humanResourceManager.DepartmentList)
                {
                    if (department.Name.Trim().ToUpper() == departmentname.Trim().ToUpper())
                    {
                        foreach (Employee employee in department.Employeelist)
                        {
                            if (employee != null)
                            {
                                checkemplo = false;
                            }
                        }
                        if (checkemplo == true)
                        {
                            Console.WriteLine($"There is no employees in {department.Name} Department.");
                            return;
                        }
                        checkdep = false;
                    }
                }
                if (checkdep == true)
                {
                    Console.WriteLine($"There is no {departmentname} Department in our list. Please try again.");
                    departmentname = Console.ReadLine();
                }
            }

            Console.WriteLine("Write down the employee's NO:");
            string no = Console.ReadLine();

            while (!Regex.IsMatch(no, "^.*[a-zA-Z]{2}[0-9]{4}.*$"))
            {
                Console.WriteLine($"There is no Employee with {no} No in Department's Employees list.\nThe No of employee must contain 2 letters and 4 numbers.\nTry again:");
                no = Console.ReadLine();
            }

            Console.WriteLine("BYE!");
            humanResourceManager.RemoveEmployee(no, departmentname);
        }

        static void CalcSalaryAverage(ref HumanResourceManager humanResourceManager) 
        {

            if (humanResourceManager.DepartmentList.Length <= 0)
            {
                Console.WriteLine($"There are no Departments. Please add them first of all.");
                return;
            }
            foreach (Department department in humanResourceManager.DepartmentList)
            {
                if (department.Employeelist.Length > 0)
                {
                    Console.WriteLine($"\nFor {department.Name} Department with {department.Employeelist.Length} employees in it:");
                    department.CalcSalaryAverage();
                    return;
                }
                else
                {
                    Console.WriteLine($"\nThere are no employees in {department.Name}. Please add them first of all to see Salary Average.");
                }

            }

        }
    } 
}
