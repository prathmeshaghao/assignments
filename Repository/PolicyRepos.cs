using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using InsuranceManagementSystem.Interfaces;
using InsuranceManagementSystem.Models;
using InsuranceManagementSystem.Utility;

namespace InsuranceManagementSystem.Repositories
{
    public class PolicyRepos : IPolicyRepos
    {
        private readonly string connectionString = DbConnUtil.GetConnectionString();

        public void AddPolicy(Policy policy)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "INSERT INTO Policies (PolicyHolderName, PolicyType, StartDate, EndDate) " +
                                "VALUES (@PolicyHolderName, @PolicyType, @StartDate, @EndDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PolicyHolderName", policy.PolicyHolderName);
                        command.Parameters.AddWithValue("@PolicyType", (int)policy.PolicyType);
                        command.Parameters.AddWithValue("@StartDate", policy.StartDate);
                        command.Parameters.AddWithValue("@EndDate", policy.EndDate);

                        if (command.ExecuteNonQuery() > 0)
                            Console.WriteLine("Policy added successfully.");
                        else
                            Console.WriteLine("Error: Policy not added.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding policy: {ex.Message}");
                }
            }
        }

        public void UpdatePolicy(int policyID, Policy updatedPolicy)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "UPDATE Policies SET PolicyHolderName = @PolicyHolderName, " +
                                "PolicyType = @PolicyType, StartDate = @StartDate, EndDate = @EndDate " +
                                "WHERE PolicyID = @PolicyID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PolicyID", policyID);
                        command.Parameters.AddWithValue("@PolicyHolderName", updatedPolicy.PolicyHolderName);
                        command.Parameters.AddWithValue("@PolicyType", (int)updatedPolicy.PolicyType);
                        command.Parameters.AddWithValue("@StartDate", updatedPolicy.StartDate);
                        command.Parameters.AddWithValue("@EndDate", updatedPolicy.EndDate);

                        if (command.ExecuteNonQuery() > 0)
                            Console.WriteLine("Policy updated successfully.");
                        else
                            Console.WriteLine("Error: Policy not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating policy: {ex.Message}");
                }
            }
        }

        public Policy SearchPolicyById(int policyID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "SELECT * FROM Policies WHERE PolicyID = @PolicyID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PolicyID", policyID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Policy(
                                    (int)reader["PolicyID"],
                                    reader["PolicyHolderName"].ToString(),
                                    (PolicyType)Enum.ToObject(typeof(PolicyType), reader["PolicyType"]),
                                    (DateTime)reader["StartDate"],
                                    (DateTime)reader["EndDate"]
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching policy: {ex.Message}");
                }
                return null;
            }
        }

        public List<Policy> ViewAllPolicies()
        {
            List<Policy> policies = new List<Policy>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "SELECT * FROM Policies";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            policies.Add(new Policy(
                                (int)reader["PolicyID"],
                                reader["PolicyHolderName"].ToString(),
                                (PolicyType)Enum.ToObject(typeof(PolicyType), reader["PolicyType"]),
                                (DateTime)reader["StartDate"],
                                (DateTime)reader["EndDate"]
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching policies: {ex.Message}");
                }
            }
            return policies;
        }

        public void DeletePolicy(int policyID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "DELETE FROM Policies WHERE PolicyID = @PolicyID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PolicyID", policyID);

                        if (command.ExecuteNonQuery() > 0)
                            Console.WriteLine("Policy deleted successfully.");
                        else
                            Console.WriteLine("Error: Policy not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting policy: {ex.Message}");
                }
            }
        }

        public List<Policy> ViewActivePolicies()
        {
            List<Policy> activePolicies = new List<Policy>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "SELECT * FROM Policies WHERE EndDate > GETDATE()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            activePolicies.Add(new Policy(
                                (int)reader["PolicyID"],
                                reader["PolicyHolderName"].ToString(),
                                (PolicyType)Enum.ToObject(typeof(PolicyType), reader["PolicyType"]),
                                (DateTime)reader["StartDate"],
                                (DateTime)reader["EndDate"]
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching active policies: {ex.Message}");
                }
            }
            return activePolicies;
        }
    }
}
