using System;
using AssignmentDay6;

namespace AssignmentDay6
{
    class Program
    {
        static void Main()
        {
            BankQueueSystem bankQueue = new BankQueueSystem();
            UniversityWorkshopRegistration workshopRegistration = new UniversityWorkshopRegistration();

            while (true)
            {
                Console.WriteLine("\nSelect a program:");
                Console.WriteLine("1. Bank Token System");
                Console.WriteLine("2. University Workshop Registration");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunBankQueue(bankQueue);
                        break;
                    case "2":
                        RunWorkshopRegistration(workshopRegistration);
                        break;
                    case "3":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void RunBankQueue(BankQueueSystem bankQueue)
        {
            while (true)
            {
                Console.WriteLine("\nBank Token System:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Serve Customer");
                Console.WriteLine("3. Check Next Customer");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter customer name: ");
                        string name = Console.ReadLine();
                        bankQueue.AddCustomer(name);
                        break;
                    case "2":
                        bankQueue.ServeCustomer();
                        break;
                    case "3":
                        bankQueue.CheckNextCustomer();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void RunWorkshopRegistration(UniversityWorkshopRegistration workshopRegistration)
        {
            while (true)
            {
                Console.WriteLine("\nUniversity Workshop Registration:");
                Console.WriteLine("1. Register Student");
                Console.WriteLine("2. Show Registrations");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter workshop name: ");
                        string workshop = Console.ReadLine();
                        Console.Write("Enter student ID: ");
                        if (int.TryParse(Console.ReadLine(), out int studentId))
                        {
                            workshopRegistration.RegisterStudent(workshop, studentId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid student ID. Please enter a number.");
                        }
                        break;
                    case "2":
                        workshopRegistration.ShowRegistrations();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}
