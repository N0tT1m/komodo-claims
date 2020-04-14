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
                        Queue<Claim> claims = _repo.GetAllClaims();
                        Console.WriteLine(String.Format($"{"ClaimID",-20} {"Type",-20} {"Description",-20} {"Amount",-20}" +
                        $"{"DateOfAccident",-30} {"DateOfClaim",-30} {"IsValid",-20}\n\n"));
                        foreach (var claim in claims)
                        {
                            claim.PrintClaims();
                            Console.WriteLine("\n");
                        }
                        break;
                    case 2:
                        try
                        {
                            Queue<Claim> claimQueue = _repo.GetAllClaims();
                            Claim claim = new Claim();
                            claim = claimQueue.First();
                            claim.PrintClaim();
                            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
                            if (Console.ReadLine().ToLower() == "y" +
                                "")
                            {

                                if (claim == null)
                                {
                                    System.Console.WriteLine("The queue is currently empty.");
                                }
                                else
                                {
                                    _repo.NextClaimInQueue();
                                }
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
