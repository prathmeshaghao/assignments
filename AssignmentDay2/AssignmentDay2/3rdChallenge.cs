using System;
using System.Runtime.InteropServices;

internal class checkBallence
{
    static void Main()
    {
        int[] userIds = { 1, 2, 3, 4, 5 };
        double[] balances = { 200.3, 400.4, 863.4, 924.56, 345.3 };

        int userId = 0;
        bool validUser = false;

        while (!validUser)
        {
            Console.WriteLine("Enter User ID to check balance");
            userId = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userIds.Length; i++)
            {
                if (userIds[i] == userId)
                {
                    Console.WriteLine($"Yours balance for Id:{userId} is {balances[i]:F2}");
                    validUser = true;
                    break;
                }
            }

            if (!validUser)
            {
                Console.WriteLine($"The ID you have entered is not found in database , Please Try Again");
            }
        }
    }
}