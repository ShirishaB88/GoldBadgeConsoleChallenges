using Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Claims_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddClaimsToTheQueue()
        {
            Claims claimItems = new Claims();
            ClaimsRepoistory claimsRepo = new ClaimsRepoistory();

            bool addResults = claimsRepo.AddClaimsToTheQueue(claimItems);
            Assert.IsTrue(addResults);


        }

        [TestMethod]
        public void GetAllClaims()
        {
           
            Claims claimItems = new Claims();
            ClaimsRepoistory claimsRepo = new ClaimsRepoistory();

            claimsRepo.AddClaimsToTheQueue(claimItems);
            Queue<Claims> claimsQueue = claimsRepo.GetAllClaims();
            bool hasClaimItems = claimsQueue.Contains(claimItems);

            Assert.IsTrue(hasClaimItems);


        }

        private Claims _claimItems;
        private ClaimsRepoistory _claimRepo;

        [TestInitialize]

        public void Arrange()
        {
            _claimRepo = new ClaimsRepoistory();
            _claimItems = new Claims(1, ClaimType.Car, "Car accident on 464.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            _claimItems = new Claims(2, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            _claimRepo.AddClaimsToTheQueue(_claimItems);
        }

        //ViewViewNextClaim

        [TestMethod]
        public void ViewNextClaimTest()
        {
            Queue<Claims> claimsQueue = _claimRepo.GetAllClaims();
           Claims nextClaimItem = claimsQueue.Peek();

            Assert.AreEqual(_claimItems, nextClaimItem);
        }

        //ProcessClaim
        [TestMethod]
        public void ProcessClaimTest()
        {
            Queue<Claims> claimsqueue = _claimRepo.GetAllClaims();
            Claims claimItem = claimsqueue.Dequeue();

            Assert.AreEqual(_claimItems, claimItem);

        }

    }
}
