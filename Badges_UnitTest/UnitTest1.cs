using Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badges_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddAddNewBadgesToTheDictinary_ShouldGetCorrectBoolean()
        {
            Badges badges = new Badges();
            BadgesRepository badgesRepo = new BadgesRepository();

            bool addResults = badgesRepo.AddNewBadgesToTheDictinary(badges);

            Assert.IsTrue(addResults);


        }

        [TestMethod]
        public void GetAllBadges_ShouldGetCorrectBoolean()
        {
            Badges badges = new Badges();
            BadgesRepository badgeRepo = new BadgesRepository();

            badgeRepo.AddNewBadgesToTheDictinary(badges);
            Dictionary<int, Badges> badgeDict = badgeRepo.GetAllBadges();
            bool hasbadges = badgeDict.ContainsValue(badges);

            Assert.IsTrue(hasbadges);

        }

        private Badges _badges;
        private BadgesRepository _badgesRepo;

        [TestInitialize]

        public void Arrange()
        {
            _badgesRepo = new BadgesRepository();
            _badges = new Badges(12345, new List<string>() { "A7" }); 
            _badges = new Badges(22345, new List<string>() { "A1", "A4", "B1", "B2" });

            _badgesRepo.AddNewBadgesToTheDictinary(_badges);

        }

        [TestMethod]
        public void GetBadgeByTheKey_ShouldGetCorrectBadge()
        {
            Badges searchBadge = _badgesRepo.GetBadgesByTheKey(1);
            Assert.AreEqual(searchBadge, _badges);

        }

        [TestMethod]
        public void UpdatingExistingBadges_ShouldReturnTrue()
        {
            //Arrange
            Badges newBadge = new Badges(52345, new List<string>() { "A7", "A2" });
            
            //Act
            bool updatebadge = _badgesRepo.UpdateExistingBadges(1, newBadge);

            //Assert
            Assert.IsTrue(updatebadge);
        }


        [TestMethod]
        public void ZDeletebadgeDoorsExistingBadges_ShoudGetCorrectBoolean()
        {
            //Badges existingBadge = _badgesRepo.GetBadgesByTheKey(1);
            bool expected = true;
            bool deleteBadgeDoor = _badgesRepo.DeleteAllDoorsFromAnExistingBadge(1);
            Assert.AreEqual(expected, deleteBadgeDoor);

        }



    }
}
