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
                Console.WriteLine($"===== Hello dear user =====\n" + "\n" +
                    $"1. -- Show all departments\n" +
                    $"2. -- Add department\n" +
                    $"3. -- Edit department\n" +
                    $"4. -- Get department workers\n" +
                    $"5. -- Get Workers\n" +
                    $"6. -- Add employee\n" +
                    $"7. -- Edit employee\n" +
                    $"8. -- Remove employee\n" +
                    $"9. -- Exit\n" +
                    $"+_+_+_+_+_+_+_+_+_+_+_+_+ ");

                string userchoice = Console.ReadLine();
                byte userchoicenum;
                while (!byte.TryParse(userchoice, out userchoicenum) || userchoicenum < 1 || userchoicenum > 10)
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
                    //case 7:
                    //    EditEmployee(ref humanResourceManager);
                    //    break;
                    //case 8:
                    //    RemoveEmployee(ref humanResourceManager);
                    //    break;
                    case 9:
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
                Console.WriteLine("\nDepartments list:\n");
                foreach (Department department in humanResourceManager.DepartmentList)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("\nSorry but there are no Departments in system. Try to add some.\n");
                return; // ili bez returna
            }
        }

        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("\nWelcome to Department creator.\nPlease write down name of Department that you are going to add:");
            string name = Console.ReadLine();   // NAME

            while (name.Length < 2 || !Regex.IsMatch(name, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(name, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven name {name} for Department is not appropriate.\n1.It must contain at least 2 elements.\nIt MUST NOT contain something other than letters or whitespaces.");
                name = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the worker limit that you are going to implement");
            string workerlimitstr = Console.ReadLine();    // WORKER LIMIT
            int workerlimitint;

            while (!int.TryParse(workerlimitstr, out workerlimitint) || workerlimitint < 1 || workerlimitint > 50)
            {
                Console.WriteLine("\nThe worker limit is not appropriate. Choose limit from 1 to 50.");
                workerlimitstr = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the salary limit that you are going to implement");
            string salarylimitstr = Console.ReadLine();   //  SALARY LIMIT

            while (!Regex.IsMatch(salarylimitstr, @"^\d+$"))
            {
                Console.WriteLine($"\nThe salary limit is not appropriate.\n1.Salary limit must be written as numbers.\n2.Salary limit should be minimum {workerlimitint * 250} for your Worker Limit.\nTry again.");
                salarylimitstr = Console.ReadLine(); // TUT KAKAYA TO PROBLEMA S ZAPOMINANIEM V PAMATI  
            }

            double salarylimitint = double.Parse(salarylimitstr);

            humanResourceManager.AddDepartment(name, workerlimitint, salarylimitint);

            Console.WriteLine("Success!");
        }

        static void EditDepartment(ref HumanResourceManager humanResourceManager)
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

            Console.WriteLine("Write down the name of department that you want to edit:");
            string inputdepname = Console.ReadLine(); // eto staroe ima

            foreach (Department department in humanResourceManager.DepartmentList)
            {
                while (department.Name != inputdepname.Trim().ToUpper())
                {
                    Console.WriteLine($"Declared {inputdepname.Trim().ToUpper()} Department has not been found.\nPlease try again.");
                    inputdepname = Console.ReadLine();
                    while (!Regex.IsMatch(inputdepname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(inputdepname, @"^\S+(?: \S+)*$"))
                    {
                        Console.WriteLine($"There is no Department called {inputdepname.Trim().ToUpper()} in Departments list. Glance again on list."); //isprav 
                        inputdepname = Console.ReadLine();
                    }
                }
            }

            Console.WriteLine($"\nWe have found {inputdepname.Trim().ToUpper()} Department in system. Please enter the new name:\n");
            
            string changedname = null;

            changedname = Console.ReadLine();

            while (!Regex.IsMatch(changedname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(changedname, @"^\S+(?: \S+)*$") || changedname.Length < 2)
            {
                Console.WriteLine($"\nDeclared {changedname.Trim().ToUpper()} cannot be assigned as Department name.\n1.Please use ONLY letters.\nPlease write at least 2 characters.");
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

            while (!double.TryParse(salarylimitstr, out salarylimit) || salarylimit < 250 * workerlimit)
            {
                Console.WriteLine($"\nSalary limit can be declared only as numbers and must be minimum {workerlimit * 250}.\nTry again:"); //////////////////problema tut on ne govorit dostatochno infi a takje proverit _salary v departaments i taje v service i dopisat remove employee i poslednee shto ostalos
                salarylimitstr = Console.ReadLine();
            }
            Console.WriteLine("Success!");

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

            Console.WriteLine("Write down the name of department in which you want to add an employee:");
            string inputdepname = Console.ReadLine();

            foreach (Department department in humanResourceManager.DepartmentList)
            {
                while (department.Name != inputdepname.Trim().ToUpper())
                {
                    Console.WriteLine($"Declared {inputdepname.Trim().ToUpper()} Department has not been found.\nPlease try again.");
                    inputdepname = Console.ReadLine();
                    while (!Regex.IsMatch(inputdepname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(inputdepname, @"^\S+(?: \S+)*$"))
                    {
                        Console.WriteLine($"There is no Department called {inputdepname.Trim().ToUpper()} in Departments list. Glance again on list."); //isprav 
                        inputdepname = Console.ReadLine();
                    }
                }
            }

            Console.WriteLine("Success!\nNow write employee Name:");
            string name = Console.ReadLine();

            while (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine($"{name} name is written in a wrong way. Use only letters.");
                name = Console.ReadLine();
            }

            Console.WriteLine("Success!\nNow write employee Surname:");
            string surname = Console.ReadLine();

            while (!Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine($"{surname} surname is written in a wrong way. Use only letters.");
                surname = Console.ReadLine();
            }

            Console.WriteLine("Success!\nWrite employee's Age:");
            byte age;

            while (!byte.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine($"Age {age} you wrote is not appropriate. Please use only numbers.");
                byte.TryParse(Console.ReadLine(), out age);
            }

            Console.WriteLine("Success!\nWrite employee's position:");
            string position = Console.ReadLine();

            while (!Regex.IsMatch(position, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine($"{position} position is written in a wrong way. Use only letters.");
                position = Console.ReadLine();
            }

            Console.WriteLine("Success!\nWrite employee's salary:");
            double salary;

            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine($"Salary {salary} you wrote is not appropriate. Please use only Numbers.");
                double.TryParse(Console.ReadLine(), out salary);
            }





            humanResourceManager.AddEmployee(name, surname, age, position, salary, departmentname);

        }

        static void GetDepartmentWorkers(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.DepartmentList.Length > 0)
            {
                Console.WriteLine($"There are {humanResourceManager.DepartmentList.Length} Departments, choose the name of one of them to get workers it contains:");
                foreach (Department department in humanResourceManager.DepartmentList)
                {
                    Console.WriteLine(department);
                }
            } // ESLI EST VASHE V PAMATI DEPARTMANETI YA IX POKAZIVAYU
            else
            {
                Console.WriteLine($"There are no Departments. Please add them first of all.");
                return;
            }

            Console.WriteLine("Write down the name of department workers of which you want to get:");
            string inputdepname = Console.ReadLine();

            while (!Regex.IsMatch(inputdepname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(inputdepname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"There is no Department called {inputdepname} in Departments list. Glance again on list.");
                inputdepname = Console.ReadLine();
            }

            foreach (Department department in humanResourceManager.DepartmentList)
            {
                if (department.Name == inputdepname.Trim().ToUpper())
                {
                    if (department.Employeelist.Length > 0)
                    {
                        foreach (Employee employee in department.Employeelist)
                        {
                            Console.WriteLine(employee);
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"There is no employees in {department} Department. Please add at least one.");
                        return;
                    }
                }
            }
            Console.WriteLine($"There is no Department named {inputdepname}. Please try again.");
        }

        static void GetWorkersList(ref HumanResourceManager humanResourceManager) 
        {
            if (humanResourceManager.DepartmentList.Length > 0)
            {
                Console.WriteLine($"There are {humanResourceManager.DepartmentList.Length} Departments, choose the name of one of them to get workers it contains:");
                foreach (Department department in humanResourceManager.DepartmentList)
                {
                    if (department.Employeelist.Length > 0)
                    {
                        foreach (Employee employee in department.Employeelist)
                        {
                            Console.WriteLine($"Employee Name: {employee}\nDepartment: {department}\nEmployee Number: {employee.No}"); // prover
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



        }
    }
