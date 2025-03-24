using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//Sorry for the bad structuring ma'am ,I am doing every program in a folder itself so for running 2nd code i.e password chcker we have to comment the whole 1st code i.e Car Name System
//I will take care that this wont happen for next week

namespace AssignmentDay3
{
    internal class _2ndQ
    {
        static bool IsValidPassword(string password)
        {
            if (password.Length < 6)
            {
                Console.WriteLine("Password must be at least 6 characters long.");
                return false;
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                Console.WriteLine("Password must contain at least one uppercase letter.");
                return false;
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                Console.WriteLine("Password must contain at least one digit.");
                return false;
            }

            return true;
        }

        static void Main()
        {
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (IsValidPassword(password))
            {
                Console.WriteLine("Password is valid.");
            }
            else
            {
                Console.WriteLine("Password is invalid. Please try again.");
            }
        }
    }
}
