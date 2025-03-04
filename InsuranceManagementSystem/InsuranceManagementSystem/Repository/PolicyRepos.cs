using System;
using System.Collections.Generic;
using InsuranceManagementSystem.Models;
using InsuranceManagementSystem.Interfaces;
using InsuranceManagementSystem.Exceptions;


namespace InsuranceManagementSystem.Repository
{
    public class PolicyRepos : IPolicyRepos
    {
        private Dictionary<int, Policy> policies = new Dictionary<int, Policy>();

        public PolicyRepos() { 
         policies = new Dictionary<int, Policy>();
        }
        public void AddPolicy(Policy policy)
        {
            if (policies.ContainsKey(policy.PolicyID)) 
            {
                Console.WriteLine("Policy with this ID already exist");
                return;
            }
            policies[policy.PolicyID] = policy;
            Console.WriteLine("Policy added succesfully");
        }
        public List<Policy> ViewAllPolicies()
        {
            return new List<Policy>(policies.Values);
        }

        public Policy SearchPolicyById(int policyID)
        {
            if (policies.TryGetValue(policyID, out Policy policy))
            {
                return policy;
            }
            throw new PolicyNotFoundException($"Policy with Id {policyID} not found in database.");
        }
        public void UpdatePolicy(int policyID,Policy updatedPolicy)
        {
            if (!policies.ContainsKey(policyID)) 
            {
            throw new PolicyNotFoundException($"Policy with Id {policyID} not found in database.");     
            }

            policies[policyID].PolicyHolderName = updatedPolicy.PolicyHolderName;
            policies[policyID].PolicyID = updatedPolicy.PolicyID;
            policies[policyID].StartDate = updatedPolicy.StartDate;
            policies[policyID].EndDate = updatedPolicy.EndDate;

            Console.WriteLine("\nUpdates Successfully");

        }
        public void DeletePolicy(int policyID)
        {
            if (!policies.ContainsKey(policyID))
            {
                throw new PolicyNotFoundException($"Policy with Id {policyID} not found in database.");
            }

            Console.WriteLine($"You sure you want to delete this policy with Id : {policyID} ? \t (Yes / No)");
            string confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation == "yes")
            {
                policies.Remove(policyID);
                Console.WriteLine($"\nPolicy with Id : {policyID} deleted successfully");
            }
            else
            {
                Console.WriteLine($"\nPolicy with Id : {policyID} is not deleted");
            }

        }
        public List<Policy> ViewActivePolicies()
        {
            List<Policy> activePolicies = new List<Policy>();

            foreach (var policy in policies.Values)
            {
                if (policy.IsActive())
                {
                    activePolicies.Add(policy);
                }
            }

            return activePolicies;
        }
    }
}