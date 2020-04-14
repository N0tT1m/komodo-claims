using System.Collections.Generic;

namespace KomodoClaimsConsole
{
    internal interface IClaimRepository
    {
        Queue<Claim> GetAllClaims();
        Claim NextClaimInQueue();
        bool CreateNewClaim(Claim claim);
    }
}