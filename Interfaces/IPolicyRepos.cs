using InsuranceManagementSystem.Models;
using System.Collections.Generic;

namespace InsuranceManagementSystem.Interfaces
{
    public interface IPolicyRepos
    {
        void AddPolicy(Policy policy);
        List<Policy> ViewAllPolicies();
        Policy SearchPolicyById(int policyID);
        void UpdatePolicy(int policyID, Policy updatedPolicy);
        void DeletePolicy(int policyID);
        List<Policy> ViewActivePolicies();
    }
}