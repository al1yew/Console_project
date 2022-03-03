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
                    //case 3:
                    //    EditDepartment(ref humanResourceManager);
                    //    break;
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
            string name = Console.ReadLine();/////////////////////

            while (!Regex.IsMatch(name, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(name, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven name {name} for Department is not appropriate. It MUST NOT contain something more that letters or whitespaces.");
                name = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the worker limit that you are going to implement");
            string workerlimitstr = Console.ReadLine();////////////////////
            int workerlimitint;

            while (!int.TryParse(workerlimitstr, out workerlimitint) || workerlimitint < 1 || workerlimitint > 50)
            {
                Console.WriteLine("\nThe worker limit is not appropriate. Choose limit from 1 to 40.");
                workerlimitstr = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the salary limit that you are going to implement");
            string salarylimitstr = Console.ReadLine();////////////////////
            double salarylimitint;

            while (!double.TryParse(salarylimitstr, out salarylimitint))
            {
                Console.WriteLine("\nThe salary limit is not appropriate. Salary limit should be minimum {workerlimitint * 250} for your Worker Limit");
                workerlimitstr = Console.ReadLine();
            }


            humanResourceManager.AddDepartment(name, workerlimitint, salarylimitint);
        }
    }
}
