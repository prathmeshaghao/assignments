using System;
using InsuranceManagementSystem.Models;
using InsuranceManagementSystem.Repository;
using InsuranceManagementSystem.Exceptions;
using static InsuranceManagementSystem.Models.Policy;


namespace InsuranceManagementSystem.Repository
{
    class Program
    {

        static void Main()
        {


            PolicyRepos policyRepos = new PolicyRepos();
            bool exit = false;

            while (!exit) {

                Console.WriteLine("================================================================================");
                Console.WriteLine("\n ==== Welcome to Insurance Management System ==== ");
                Console.WriteLine("\n1. Add a New Policy");
                Console.WriteLine("2. View all Policies");
                Console.WriteLine("3. Search Policies by ID");
                Console.WriteLine("4. Update Policy Details");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. View Active Policies");
                Console.WriteLine("7. Exit");
                Console.Write("\nChoose One Option ");
                Console.WriteLine("================================================================================");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("\nEnter Policy Id: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("\nEnter Policy Holder Name: ");
                            string name = Console.ReadLine();
                            Console.Write("\nEnter Policy Type (Life, Health, Vehicle, Property): ");
                            PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);
                            Console.Write("\nEnter Start Date (yyyy-MM-dd): ");
                            DateTime start = DateTime.Parse(Console.ReadLine());
                            Console.Write("\nEnter End Date (yyyy-MM-dd): ");
                            DateTime end = DateTime.Parse(Console.ReadLine());

                            policyRepos.AddPolicy(new Policy
                            {
                                PolicyID = id,
                                PolicyHolderName = name,
                                Type = type,
                                StartDate = start,
                                EndDate = end
                            });
                        
                        }
                        catch (Exception ex)
                        {
                        Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;

                    case "2":
                        Console.WriteLine("\nAll Existing Policies:");
                        foreach (var policy in policyRepos.ViewAllPolicies())
                        {
                            Console.WriteLine(policy);
                        }
                        break;

                    case "3":
                        Console.Write("\nEnter Policy ID: ");
                        try
                        {
                           int searchId = int.Parse(Console.ReadLine());
                            Console.WriteLine(policyRepos.SearchPolicyById(searchId));
                        }
                        catch (PolicyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "4":
                        try
                        {
                            Console.Write("\nEnter Policy ID to update: ");
                            int updateId = int.Parse(Console.ReadLine());
                            Console.Write("\nEnter New Policy Holder Name: ");
                            string newName = Console.ReadLine();
                            Console.Write("\nEnter New Policy Type (Life, Health, Vehicle, Property): ");
                            PolicyType newType = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);
                            Console.Write("\nEnter New Start Date (yyyy-MM-dd): ");
                            DateTime newStart = DateTime.Parse(Console.ReadLine());
                            Console.Write("\nEnter New End Date (yyyy-MM-dd): ");
                            DateTime newEnd = DateTime.Parse(Console.ReadLine());

                            policyRepos.UpdatePolicy(updateId, new Policy { PolicyHolderName = newName, Type = newType, StartDate = newStart, EndDate = newEnd });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "5":
                        Console.Write("\nEnter Policy ID to delete: ");
                        try
                        {
                            int deleteId = int.Parse(Console.ReadLine());
                            policyRepos.DeletePolicy(deleteId);
                        }
                        catch (PolicyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "6":
                        Console.WriteLine("\nActive Policies:");
                        foreach (var policy in policyRepos.ViewActivePolicies())
                        {
                            Console.WriteLine(policy);
                        }
                        break;

                    case "7":
                        exit = true;
                        Console.WriteLine("\nExiting Program...");
                        return;

                    default:
                        Console.WriteLine("\nInvalid Choice");
                        break;
                    }
                }
            }
        }
    }

