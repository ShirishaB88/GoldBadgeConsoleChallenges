using Cafe.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddItemsToCafeMenuList_ShouldGetCoorectBoolean()
        {   
            //Arrange
            CafeMenu menuItems = new CafeMenu();
            CafeMenuRepository menuRepository = new CafeMenuRepository();

            //Act
            bool addResult = menuRepository.AddItemsToCafeMenuList(menuItems);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetCafeMenu_ShouldReturnCorrectMenu()
        {
            CafeMenu menuItems = new CafeMenu();
            CafeMenuRepository menuRepository = new CafeMenuRepository();

            menuRepository.AddItemsToCafeMenuList(menuItems);

            List<CafeMenu> listOfMenuItems = menuRepository.GetCafeMenu();

            bool hasMeniItems = listOfMenuItems.Contains(menuItems);

            Assert.IsTrue(hasMeniItems);

        }

        private CafeMenu _menuItems;
        private CafeMenuRepository _menuRepo;

        [TestInitialize]

        public void Arrange()
        {
            _menuRepo = new CafeMenuRepository();

            _menuItems = new CafeMenu(1, "Pizza", "Falt Bread with Pizzza suace, chesse, veggies on it.", new List<string>() { "Wheat flour", "Chesse", "Pizza Sauce", "Veggies" }, 10.5);

            _menuRepo.AddItemsToCafeMenuList(_menuItems);

        }



        [TestMethod]
        public void GetMenuItemByMealName_ShouldReturnCorrectItems()
        {

            CafeMenu searchResults = _menuRepo.GetMenuItemByMealName("Pizza");

            Assert.AreEqual(_menuItems, searchResults);

        }

        [TestMethod]
        public void GetMenuItemByMealNumber()
        {
            CafeMenu searchResults = _menuRepo.GetMenuItemsByMealNumber(1);

            Assert.AreEqual(_menuItems, searchResults);

        }

        [TestMethod]
        public void ZDeleteExistingItems_ShouldGetTrue()
        {
            CafeMenu menuItems = _menuRepo.GetMenuItemByMealName("Pizza");

            bool removeResults = _menuRepo.DeleteExistingItems(menuItems);
            Assert.IsTrue(removeResults);
        }
    }
}
