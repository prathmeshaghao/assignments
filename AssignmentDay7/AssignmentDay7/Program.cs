using System;


namespace AssignmentDay7
{
    class Program
    {
        static void Main(string[] args)
        {

            // For 1st Ques
            Console.WriteLine("\n ===== 1st Question =====");
            Employee emp = new Employee("Prathmesh Aghao", new DateTime(2022, 2, 18));
            Console.WriteLine($"Joining year of {emp.Name} is {emp.JoiningDate.Year} and he {emp.getHowMuchExp()} years of Total Experience");


            Console.WriteLine("\n ===== 2nd Question =====");
            //For 2nd Ques
            List<Product> products = new List<Product>
            {

            new Product(1, "PC", "Electronics", 50000),
            new Product(2, "Laptop", "Electronics", 3000),
            new Product(3, "Book", "Book", 900),
            new Product(4, "Pen", "Stationary", 20),
            new Product(5, "Paper", "Stationary", 300),
           
            };

            var expensiveProd = products
                .Where(p => p.Category == "Electronics" && p.Price >= 1000)
                .ToList();

            Console.WriteLine("\nElectronics Products costing more than Rs 1000:");

            foreach (var product in expensiveProd)
            {
                Console.WriteLine($"{product.Name} = Rs {product.Price} with Product Id : {product.ProductID}");
            }

            Console.WriteLine("\n ===== 3rd Question =====");


            var mostExpensiveProd = products.OrderByDescending(p => p.Price).FirstOrDefault();

            if (!mostExpensiveProd.Equals(default(Product)))
            {
                Console.WriteLine($"\nMost Expensive Product is {mostExpensiveProd.Name} " +
                    $"and its price is Rs {mostExpensiveProd.Price}");
            }

        }
    }
}