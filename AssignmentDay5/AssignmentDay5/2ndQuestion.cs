using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay5
{
    abstract class VehicleInsurance
    {
        public abstract void CalculatePremium();
    }

    class TwoWheelerInsurance : VehicleInsurance
    {
        public override void CalculatePremium()
        {
            {
                Console.WriteLine("\nInsurance for Two-Wheeler is 1000Rs");
            }
        }
    }
    class FourWheelerInsurance : VehicleInsurance
    {
        public override void CalculatePremium()
        {
            {
                Console.WriteLine("\nInsurance for Four-Wheeler is 2500Rs");
            }
        }
    }
    class CommercialInsurance : VehicleInsurance
    {
        public override void CalculatePremium()
        {
            {
                Console.WriteLine("\nInsurance for Commercial Vechile is 5000Rs");
            }
        }
    }
    class InsuranceSystem
    {
        public static void Run()
        {
            Console.WriteLine("\n ===== Vehicle Insurance Policies ===== ");

            VehicleInsurance policy1 = new TwoWheelerInsurance();
            VehicleInsurance policy2 = new FourWheelerInsurance();
            VehicleInsurance policy3 = new CommercialInsurance();

            policy1.CalculatePremium();
            policy2.CalculatePremium();
            policy3.CalculatePremium();
        }


    }
}