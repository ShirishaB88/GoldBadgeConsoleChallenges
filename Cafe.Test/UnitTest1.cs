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
        public void AddItemsToCafeMenuList_ShouldGetCorectBoolean()
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

            bool hasMenuiItems = listOfMenuItems.Contains(menuItems);

            Assert.IsTrue(hasMenuiItems);

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
        public void GetItemsByDescription()
        {
            CafeMenu searchresults = _menuRepo.GetItemsByDescription("Falt Bread with Pizzza suace, chesse, veggies on it.");
            Assert.AreEqual(_menuItems, searchresults);

        }

        [TestMethod]
        public void GetItemByPrice()
        {
            CafeMenu searchResults = _menuRepo.GetItemByPrice(10.5);
            Assert.AreEqual(_menuItems, searchResults);
        }

        [TestMethod]
        public void UpdateCafeMenuItems()
        {
            CafeMenu newcafeMenu = new CafeMenu(1,"CauliflowerPizza", "Glutenfree flat Bread with Pizzza suace, chesse, veggies on it.", 
                new List<string>() { "Cauliflour Crust", "Chesse", "Pizza Sauce", "Veggies" }, 12);

            bool updatedMenu = _menuRepo.UpdateCafeMenuItems(_menuItems.MealNumber, newcafeMenu);
            Console.WriteLine($"{_menuItems.MealNumber } \n" +
                $"{_menuItems.MealName} \n" +
                $"{_menuItems.Price}");
            foreach (var ingredient in _menuItems.Ingredients)
            {
                Console.WriteLine(ingredient);
            }
            Assert.IsTrue(updatedMenu);

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
