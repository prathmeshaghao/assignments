using System;

namespace InsuranceManagementSystem.Models
{
    public enum PolicyType { Life, Health, Vehicle, Property }

    public class Policy
    {
        public int PolicyID { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive()
        {
            return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
        }

        public override string ToString()
        {
            return $"Policy ID: {PolicyID}, Holder: {PolicyHolderName}, Type: {Type}, " +
                   $"Start: {StartDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}, Active: {IsActive()}";
        }
    }
}
