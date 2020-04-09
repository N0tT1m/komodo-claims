using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace KomodoClaimsConsole
{
    public class ClaimRepository : IClaimRepository
    {
        Claim claim1 = new Claim()
        {
            ClaimType = Claim.TypeClaim.Car,
            Description = "Crash on I-70",
            ClaimAmount = 4000,
            DateOfIncident = DateTime.Today,
            IsValid = true
        };

        Queue<Claim> _queue = new Queue<Claim>();

        public void SeedQueue()
        {
            _queue.Enqueue(claim1);
        }
        
        public void CreateNewClaim(Claim claim)
        {
            _queue.Enqueue(claim);
            Console.WriteLine("Success");
        }

        public Queue<Claim> GetAllClaims()
        {
            return _queue;
        }

        public Claim NextClaimInQueue()
        {
            return _queue.Dequeue();
        }
    }
}
