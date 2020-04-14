using System;
using System.Collections.Generic;
using KomodoClaimsConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimRepositoryTests
{
    [TestClass]
    public class RepositoryTests
    {
        Queue<Claim> queue = new Queue<Claim>();
        ClaimRepository repo = new ClaimRepository();
        Claim claim = new Claim()
        {
            ClaimType = Claim.TypeClaim.Car,
            Description = "Crash on I-70",
            ClaimAmount = 4000,
            DateOfIncident = DateTime.Parse("1/2/2020"),
            DateOfClaim = DateTime.Today,
            IsValid = true
        };

        [TestMethod]
        public void CreateNewClaim_ShouldCreateNewClaim()
        {
            bool wasCreated = repo.CreateNewClaim(claim);
            Assert.IsTrue(wasCreated);
        }

        [TestMethod]
        public void GetNextInQueue_ShouldReturnTheNextClaim()
        {
            repo.SeedQueue();

            Claim claim1 = claim;
            Claim claim2 = repo.NextClaimInQueue();

            Assert.AreEqual(claim1, claim2);
        }
    }
}
