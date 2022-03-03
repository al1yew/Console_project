using ConsoleProject_1.Services;
using System;

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
                Console.WriteLine($"-- We are preparing the process...");

                switch (userchoicenum)
                {
                    case 1:
                    //budu otpravlat vo vse keysi metodi
                    case 2:
                    //budu otpravlat vo vse keysi metodi
                    case 3:
                    //budu otpravlat vo vse keysi metodi
                    case 4:
                    //budu otpravlat vo vse keysi metodi
                    case 5:
                    //budu otpravlat vo vse keysi metodi
                    case 6:
                    //budu otpravlat vo vse keysi metodi
                    case 7:
                    //budu otpravlat vo vse keysi metodi
                    case 8:
                        return;
                }




            } while (true);
        }
    }
}
