using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsConsole
{
    interface IClaim
    {
        int ClaimID { get; set; }
        Claim.TypeClaim ClaimType { get; set; }
        string Description { get; set; }
        double ClaimAmount { get; set; }
        DateTime DateOfIncident { get; set; }
        DateTime DateOfClaim { get; set; }
        bool IsValid { get; set; }

        void PrintClaim();
        void PrintClaims();
    }
}
