using System;
using System.Runtime.InteropServices;

internal class salaryCount
{
    static void Main()
    {
        Console.WriteLine("Enter your salary : ");
        double baseSalary = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter rating : ");
        double rating = Convert.ToInt32(Console.ReadLine());

        double taxDeduce = baseSalary * 0.1;
        double bonus = 0;

        if (rating >= 8)
        {
            bonus = baseSalary * 0.2;
        }
        else if (rating >= 5 && rating < 8)
        {
            bonus = baseSalary * 0.1;

        }
        double netSal = baseSalary - taxDeduce + bonus;
        Console.WriteLine($"Net Salary Offered is - {netSal}");



    }
}

