using System;
using System.Runtime.InteropServices;

internal class onlineBooking
{
    static void Main()
    {

        Console.WriteLine($"General Ticket - 200rs ");
        Console.WriteLine($"Sleeper Tickets - 500rs ");
        Console.WriteLine($"Ac Tickets - 1000rs ");

        int totalCost = 0;

        while (true)
        {
            Console.WriteLine($"Select which ticket you want : General / Sleeper / Ac or exit to final the tickets and move to payment");
            string ticketType = Console.ReadLine().ToLower();

            if (ticketType == "exit")
            {
                break;
            }

            Console.Write("Enter number of tickets: ");
            int numberOfTickets = Convert.ToInt32(Console.ReadLine());

            int ticketPrice = 0;
            switch (ticketType)
            {
                case "general":
                    ticketPrice = 200;
                    break;
                case "sleeper":
                    ticketPrice = 500;
                    break;
                case "ac":
                    ticketPrice = 1000;
                    break;
                default:
                    Console.WriteLine($"Please enter correct ticket type, Try Again ...");
                    continue;

            }

            totalCost += ticketPrice * numberOfTickets;
            Console.WriteLine($"Current total Cost of your Tickets : {totalCost}");
        }
        Console.WriteLine($"Final Cost of your Tickets : {totalCost}");
    }
//}

