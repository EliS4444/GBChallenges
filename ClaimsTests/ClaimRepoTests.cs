using _03_KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClaimsTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        [TestMethod]
        public void AddClaim_ShouldGetCorrectBool()
        {
            Claim claim = new Claim();
            ClaimRepo repo = new ClaimRepo();

            bool addClaim = repo.AddClaim(claim);

            Assert.IsTrue(addClaim);
        }

        [TestMethod]
        public void GetClaims_ShouldReturnCorrectCollection()
        {
            Claim claim = new Claim();
            ClaimRepo repo = new ClaimRepo();
            repo.AddClaim(claim);

            Queue<Claim> claims = repo.GetAllClaims();
            bool hasClaim = claims.Contains(claim);

            Assert.IsTrue(hasClaim);
        }

        [TestMethod]
        public void PeekClaim_ShouldReturnNextClaim()
        {
            Claim claim = new Claim();
            ClaimRepo repo = new ClaimRepo();
            repo.AddClaim(claim);

            Claim nextClaim = repo.PeekClaim();

            Assert.AreEqual(nextClaim, claim);
        }

        [TestMethod]
        public void DequeueClaim_ShouldReturnTrue()
        {
            Claim claim = new Claim();
            ClaimRepo repo = new ClaimRepo();
            repo.AddClaim(claim);

            bool dequeuedClaim = repo.DequeueClaim();

            Assert.IsTrue(dequeuedClaim);
        }
    }
}
