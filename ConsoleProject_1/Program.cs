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
                    Console.WriteLine("You need to choice numbers from 1 to 9!");
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
                    //case 4:
                    //    GetDepartmentWorkers(ref humanResourceManager);
                    //    break;
                    //case 5:
                    //    GetWorkersList(ref humanResourceManager);
                    //    break;
                    //case 6:
                    //    AddEmployee(ref humanResourceManager);
                    //    break;
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
            if (humanResourceManager.Departments.Length > 0)
            {
                Console.WriteLine("Departments list:\n");
                foreach (Department department in humanResourceManager.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Sorry but there is no Departments in system. Try to add some.");
                return; // ili bez returna
            }
        }

        static void AddDepartment(ref HumanResourceManager humanResourceManager) 
        {
            Console.WriteLine("\nWelcome to Department creator.\nPlease write down name of Department that you are going to add:");
            string name = Console.ReadLine();   

            while (!Regex.IsMatch(name, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(name, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven name {name} for Department is not appropriate. It MUST NOT contain something more that letters or whitespaces.");
                name = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the worker limit that you are going to implement");
            string workerlimitstr = Console.ReadLine();   
            int workerlimitint;

            while (!int.TryParse(workerlimitstr, out workerlimitint) || workerlimitint < 1 || workerlimitint > 50)
            {
                Console.WriteLine("\nThe worker limit is not appropriate. Choose limit from 1 to 50.");
                workerlimitstr = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the salary limit that you are going to implement");
            string salarylimitstr = Console.ReadLine();   
            double salarylimitint;
            double.TryParse(salarylimitstr, out salarylimitint);

            while (!Regex.IsMatch(salarylimitstr, @"^\d+$"))
            {
                Console.WriteLine($"\nThe salary limit is not appropriate.\n1.Salary limit must be written as numbers.\n2.Salary limit should be minimum {workerlimitint * 250} for your Salary Limit.\nTry again.");
                salarylimitstr = Console.ReadLine(); // TUT KAKAYA TO PROBLEMA S ZAPOMINANIEM V PAMATI  
            }

            humanResourceManager.AddDepartment(name, workerlimitint, salarylimitint);
        }

        static void EditDepartment(ref HumanResourceManager humanResourceManager) 
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                Console.WriteLine($"There is {humanResourceManager.Departments.Length} Departments, choose the name of one that you want to edit:");
                foreach (Department department in humanResourceManager.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine($"There are no Departments. Please add them first of all.");
                return;
            }

            Console.WriteLine("Write down the name of department that you want to edit:");
            string inputdepname = Console.ReadLine(); // eto stariy

            while (!Regex.IsMatch(inputdepname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(inputdepname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"There is no Department called {inputdepname} in Departments list. Glance again on list.");
                inputdepname = Console.ReadLine();
            }

            string inputnewdepname = null; // eto noviy uje

            foreach (Department department in humanResourceManager.Departments)
            {
                if (department.Name == inputdepname)
                {
                    Console.WriteLine($"We have found {inputdepname} Department. Please enter the new name:");
                    inputnewdepname = Console.ReadLine();
                    while (!Regex.IsMatch(inputnewdepname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(inputnewdepname, @"^\S+(?: \S+)*$"))
                    {
                        Console.WriteLine($"Declared {inputnewdepname} name cannot be assigned as Department name. Please use ONLY letters.");
                        inputnewdepname = Console.ReadLine();
                    }
                }
            }







        }
    }
}
