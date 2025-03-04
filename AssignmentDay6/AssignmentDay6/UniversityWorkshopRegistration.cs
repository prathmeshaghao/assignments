using System;
using System.Collections.Generic;

namespace AssignmentDay6
{
    class UniversityWorkshopRegistration
    {
        private Dictionary<string, HashSet<int>> workshopRegistrations = new Dictionary<string, HashSet<int>>();

        public void RegisterStudent(string workshop, int studentId)
        {
            if (!workshopRegistrations.ContainsKey(workshop))
            {
                workshopRegistrations[workshop] = new HashSet<int>();
            }

            if (workshopRegistrations[workshop].Add(studentId))
            {
                Console.WriteLine($"Student {studentId} successfully registered for {workshop}.");
            }
            else
            {
                Console.WriteLine($"Student {studentId} is already registered for {workshop}. Duplicate registration not allowed.");
            }
        }

        public void ShowRegistrations()
        {
            Console.WriteLine("\nWorkshop Registrations:");
            foreach (var workshop in workshopRegistrations)
            {
                Console.WriteLine($"Workshop: {workshop.Key}, Students: {string.Join(", ", workshop.Value)}");
            }
        }
    }
}
