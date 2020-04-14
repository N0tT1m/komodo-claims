using System;
using System.Collections.Generic;
using KomodoClaimsConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimRepositoryTests
{
    [TestClass]
    public class RepositoryTests
    {
        Claim claim = new Claim()
        {
            ClaimType = Claim.TypeClaim.Car,
            Description = "Crash on I-70",
            ClaimAmount = 4000,
            DateOfIncident = DateTime.Parse("1/2/2020"),
            DateOfClaim = DateTime.Today,
            IsValid = true
        };

        Queue<Claim> queue = new Queue<Claim>();
        ClaimRepository repo = new ClaimRepository();

        [TestMethod]
        public void CreateNewClaim_ShouldCreateNewClaim()
        {
            bool wasCreated = repo.CreateNewClaim(claim);
            Assert.IsTrue(wasCreated);
        }

        [TestMethod]
        public void GetNextInQueue_ShouldReturnTheNextClaim()
        {
            queue.Enqueue(claim);

            Claim claim1 =  claim;
            Claim claim2 = queue.Dequeue();

            Assert.AreEqual(claim1, claim2);
        }

        [TestMethod]
        public void GetAllClaims_ShouldReturnQueue()
        {
            repo.SeedQueue();

            Queue<Claim> queue1 = queue;
            queue.Enqueue(claim);

            Assert.AreEqual(queue, queue1);
        }
    }
}
