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
            DateOfIncident = DateTime.Parse("1/2/2020"),
            DateOfClaim = DateTime.Today,
            IsValid = true
        };

        Queue<Claim> _queue = new Queue<Claim>();

        public void SeedQueue()
        {
            _queue.Enqueue(claim1);
        }
        
        public bool CreateNewClaim(Claim claim)
        {
            int startingCount = _queue.Count;
            _queue.Enqueue(claim);
            Console.WriteLine("Success");
            bool wasCreated = (_queue.Count > startingCount);
            return wasCreated;
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
