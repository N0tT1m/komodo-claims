using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsConsole
{
    class ProgramUI
    {
        private UserInputHelper _userInputHelper = new UserInputHelper();
        private ClaimRepository _repo = new ClaimRepository();
        Claim claim = new Claim();


        bool running = true;

        public ProgramUI(ClaimRepository claimRepository)
        {
            _repo = claimRepository;
        }

        public void Run()
        {
            int userInput;

            while (running)
            {
                Console.WriteLine("Options for dealing with claims are listed below\n" +
                    "1: See all claims\n" +
                    "2: Take care of next claim\n" +
                    "3: Enter new claim");
                int.TryParse(Console.ReadLine(), out userInput);
                switch (userInput)
                {
                    case 1:
                        Queue<Claim> queueClaim = _repo.GetAllClaims();
                        for (int index = 0; index < queueClaim.Count; index++)
                        {
                            claim.PrintClaim();
                        }
                        break;
                    case 2:

                            try
                            {
                                claim = _repo.NextClaimInQueue();
                                if (claim == null)
                                {
                                    System.Console.WriteLine("The queue is currently empty.");
                                }
                                else 
                                {
                                    claim.PrintClaim();
                                }
                            }
                            catch (InvalidOperationException)
                            {
                                System.Console.WriteLine("The queue is currently empty.");
                            }
                            break;
                    case 3:
                        claim = _userInputHelper.GetNewClaim();
                        _repo.CreateNewClaim(claim);
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
