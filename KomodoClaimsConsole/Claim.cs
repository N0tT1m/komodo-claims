using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsConsole
{
    public class Claim : IClaim
    {
        public Claim(TypeClaim claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public Claim()
        {
            
        }

        public int ClaimID { get; set; } = 1;
        public TypeClaim ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; } = false;
        public enum TypeClaim { Car = 1, Home, Theft };

        public bool VaidateEnumValue(int EnumValue)
        {
            bool success = Enum.IsDefined(typeof(TypeClaim), EnumValue);
            if (success)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid entry");
                return false;
            }
        }

        public void PrintClaim()
        {
            Console.WriteLine(String.Format($"{"ClaimID", -20} {"Type", -20} {"Description", -20} {"Amount", -20}" +
            $"{"DateOfAccident", -30} {"DateOfClaim", -30} {"IsValid", -20}\n\n"));
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format($"{ClaimID, -20} {ClaimType, -20} {Description, -20}" +
            $"{"$" + ClaimAmount, -20} {DateOfIncident, -30} {DateOfClaim, -30} {IsValid, -20}"));
            System.Console.WriteLine(sb);
        }
    }
}
