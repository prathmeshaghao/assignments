using System;
using System.Collections.Generic;

namespace AssignmentDay6
{
    class BankQueueSystem
    {
        private Queue<string> customerQueue = new Queue<string>();

        public void AddCustomer(string name)
        {
            customerQueue.Enqueue(name);
            Console.WriteLine($"Customer {name} has taken a token.");
        }

        public void ServeCustomer()
        {
            if (customerQueue.Count > 0)
            {
                string servedCustomer = customerQueue.Dequeue();
                Console.WriteLine($"Serving customer: {servedCustomer}");
            }
            else
            {
                Console.WriteLine("No customers in the queue.");
            }
        }

        public void CheckNextCustomer()
        {
            if (customerQueue.Count > 0)
            {
                Console.WriteLine($"Next customer to be served: {customerQueue.Peek()}");
            }
            else
            {
                Console.WriteLine("No customers in the queue.");
            }
        }
    }
}
