using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay4
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }


        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee Name is {Name} and his Salary is {Salary}");
        }
    }

    class Manager : Employee
    {
        public double Bonus { get; set; }

        public Manager(string name, double salary, double bonus) : base(name, salary)
        {
            Bonus = bonus;
        }

        public void DisplayManagerDetails()
        {
            Console.WriteLine($"Manager Name is {Name} and his Salary is {Salary} with a Bonus of {Bonus}");
        }


    }

    class Program
    {
        static void Main()
        {
            Employee emp = new Employee("Omkar", 80000);
            emp.DisplayEmployeeDetails();

            Manager mgr = new Manager("Vaibhav", 100000, 25000);
            mgr.DisplayManagerDetails(); ;
        }
    }

}
