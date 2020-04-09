using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsConsole
{
    public class ClaimRepository : IClaimRepository
    {

        Queue<Claim> _queue = new Queue<Claim>()
        {

        };
        UserInputHelper userInput = new UserInputHelper();

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
