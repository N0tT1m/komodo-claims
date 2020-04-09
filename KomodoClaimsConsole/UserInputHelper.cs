using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsConsole
{
    class UserInputHelper
    {
        Claim claim = new Claim();
        CultureInfo enUS = new CultureInfo("en-US");
        DateTime incidentDate;
 
        public Claim GetNewClaim()
        {
            Console.WriteLine("Please enter a claim type\n" +
                "1. For Car\n" +
                "2. For Home\n" +
                "3. For Theft");
            try
            {
                int inputForClaimType = int.Parse(Console.ReadLine());
                if (claim.VaidateEnumValue(inputForClaimType))
                {
                    switch (inputForClaimType)
                    {
                        case 1:
                            claim.ClaimType = Claim.TypeClaim.Car;
                            break;
                        case 2:
                            claim.ClaimType = Claim.TypeClaim.Home;
                            break;
                        case 3:
                            claim.ClaimType = Claim.TypeClaim.Theft;
                            break;
                    } 
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid claim type");
            }
            Console.WriteLine("Please enter a description for your claim");
            claim.Description = Console.ReadLine();
            Console.WriteLine("Please enter an amount for your claim");
            claim.ClaimAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date the incident occured");
            if (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", enUS, DateTimeStyles.None, out incidentDate))
            {
                claim.DateOfIncident = incidentDate;
            }
            string dateOfClaim = DateTime.Today.ToString();
            claim.DateOfClaim = DateTime.Parse(dateOfClaim, enUS, DateTimeStyles.NoCurrentDateDefault);
            int daysDiff = ((TimeSpan)(claim.DateOfClaim - claim.DateOfIncident)).Days;
            if (daysDiff <= 30)
            {
                Console.WriteLine((claim.DateOfClaim - claim.DateOfIncident).TotalDays);
                claim.IsValid = true;
                Console.WriteLine(claim.IsValid);
            }
            else
            {
                claim.IsValid = false;
                Console.WriteLine(claim.IsValid);
            }

            return claim;
        }
    }
}
