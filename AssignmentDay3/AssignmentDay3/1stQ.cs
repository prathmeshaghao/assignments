using System;

namespace AssignmentDay3
{
    class Car
    {
        
        private int carID;
        private string brand;
        private string model;
        private int year;
        private double price;

       
        public int CarID
        {
            get { return carID; }
            set { carID = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        
        public Car(int carID, string brand, string model, int year, double price)
        {
            Console.WriteLine("Receiving Car Information");
            CarID = carID;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }

        public Car()
        {
            Console.WriteLine("Receiving Car Information (Default Values)");
            CarID = 0;
            Brand = "Unknown";
            Model = "Unknown";
            Year = 2000;
            Price = 0.0;
        }

        
        public void PresentCarInfo()
        {
            Console.WriteLine("\nPresenting Car Information");
            Console.WriteLine($"Car ID: {CarID}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Price: ${Price}");
        }
    }

    class Program
    {
        static void Main()
        {
          
            Console.Write("Enter Car ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Enter Model: ");
            string model = Console.ReadLine();

            Console.Write("Enter Manufacturing Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            Car myCar = new Car(id, brand, model, year, price);
            myCar.PresentCarInfo();

            
            Car defaultCar = new Car();
            defaultCar.PresentCarInfo();
        }
    }
}