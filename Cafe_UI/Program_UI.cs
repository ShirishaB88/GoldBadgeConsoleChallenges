using Cafe.Repository;
using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CafeUI
{
   public  class Program_UI
    {
        private CafeMenuRepository _menuRepo = new CafeMenuRepository();
        //Method that runs/starts the application
        public void Run()
        {
            SeedMenuList();
            Menu();

        }

        private void Menu()
        {
            //Display the options to users

            bool continueToRun = true;
            while (continueToRun)
            {

                Console.Clear();

                Console.WriteLine("Select a menu option: \n" +
                    "1: Create New Menu Items \n" +
                    "2: Show All Menu Items \n" +
                    "3: View Items By Meal Name \n" +
                    "4: View Items By Meal Number \n" +
                    "5: Remove Items from Menu \n" +
                    "6: Exit");
                //Get the Users input

                string userInput = Console.ReadLine();

                // //Evaluate the users input and act according to it

                switch (userInput)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        ShowAllMenuItems();
                        break;
                    case "3":
                        ViewItemsByMealName();
                        break;
                    case "4":
                        ViewItemsBYMealNUmber();
                        break;
                    case "5":
                        RemoveItemsFromMenu();
                        break;
                    case "6":
                        //exit 
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number \n" +
                            "Press any key to continue.....");
                        Console.ReadKey();
                        break;
                }


            }

        }

        //Create New Menu Items

        private void CreateNewMenuItem()
        {
            Console.Clear();
            CafeMenu newMenuItem = new CafeMenu();

            //Meal Number
            Console.WriteLine("Enter a Meal Number for the New Menu Item");
            newMenuItem.MealNumber = int.Parse(Console.ReadLine());

            //Meal Name
            Console.WriteLine("Enter a Meal Name for the New Menu Item");
            newMenuItem.MealName = Console.ReadLine();

            //Description
            Console.WriteLine("Enter a Description for the New Menu Item");
            newMenuItem.Description = Console.ReadLine();

            //Ingredients
            bool hasAllIngredients = false;

            while (hasAllIngredients == false)
            {
                Console.WriteLine("Do you have any ingredients to add? (y/n)");

                string userInputHasIngredient = Console.ReadLine().ToLower();

                if (userInputHasIngredient == "y")
                {
                    Console.WriteLine("Enter the Ingredient to add: ");
                    string ingredient = Console.ReadLine();
                    
                    newMenuItem.Ingredients.Add(ingredient);
                }

                else
                {
                    hasAllIngredients = true;
                }

            }           
           
            //Price
            Console.WriteLine("Enter a Price for The New Menu Item");
            newMenuItem.Price = double.Parse(Console.ReadLine());

            _menuRepo.AddItemsToCafeMenuList(newMenuItem);

        }

        //View Current Menu Items 

        private void ShowAllMenuItems()
        {
            Console.Clear();
            List<CafeMenu> listOfCafeMenu = _menuRepo.GetCafeMenu();
            foreach (CafeMenu menuItem in listOfCafeMenu)
            {
                DisplayMenuItems(menuItem);
            }

            Console.WriteLine("Press any key to Continue........");
            Console.ReadKey();
        }

       
       
        //view menu items by Meal Name
        private void ViewItemsByMealName()
        {
            Console.Clear();
            Console.WriteLine("Enter a Meal Name");
            string mealName = Console.ReadLine();
            CafeMenu menuItem = _menuRepo.GetMenuItemByMealName(mealName);
            if (menuItem != null)
            {
                DisplayMenuItems(menuItem);
            }
            else
            {
                Console.WriteLine($"Invalid mealName. Could not find results{menuItem}");
            }
            Console.WriteLine("Press any key to continue..........");
            Console.ReadKey();

        }

        private void ViewItemsBYMealNUmber()
        {
            Console.Clear();

            Console.WriteLine("Enter a Meal Number");
            int mealNumber = int.Parse(Console.ReadLine());
            CafeMenu menuItem = _menuRepo.GetMenuItemsByMealNumber(mealNumber);
            if (menuItem != null)
            {
                DisplayMenuItems(menuItem);
            }
            else
            {
                Console.WriteLine($"Invalid mealNumber. Could not find results{menuItem}");
            }
            Console.WriteLine("Press any key to continue..........");
            Console.ReadKey();

        }
       
        private void RemoveItemsFromMenu()
        {
            Console.Clear();
            Console.WriteLine("Which Item do you want to remove?\n" +
                "Enter the meal Number");
            int mealNumber = int.Parse(Console.ReadLine());
            CafeMenu menuItem = _menuRepo.GetMenuItemsByMealNumber(mealNumber);
            if (menuItem != null)
            {
                _menuRepo.DeleteExistingItems(menuItem);
            }

            Console.WriteLine("Press Any key to continue.........");
            Console.ReadKey();
            
        }

        private void DisplayMenuItems(CafeMenu menuItem)
        {
            
            Console.WriteLine($"Meal Number : {menuItem.MealNumber}\n" +
                    $"Meal Name: {menuItem.MealName}\n" +
                    $"Description: {menuItem.Description}\n" +
                    $"Price: {menuItem.Price}\n" +
                    $"Ingredients: ");
                   foreach (var item in menuItem.Ingredients)
                   {
                     Console.WriteLine(item);
                   }


        }

        //seed Method
        private void SeedMenuList()
        {
            
            CafeMenu pizza = new CafeMenu(1, "Pizza", "Falt Bread with Pizzza suace, chesse, veggies on it. ",new List<string>() {"Wheat flour", "Chesse", "Pizza Sauce", "Veggies" }, 10.59);
            CafeMenu sandwitch = new CafeMenu(2, "Sandwitch", "Loaded with yummy sauces and selected patties. ", new List<string>() {"Wheat Bread","Patties of choice","Cheese","Sauce"}, 7.9);
            CafeMenu veggieWrap = new CafeMenu(3, "Veggie wrap", "Tortilla wrapped with beand and selected veggies with beans/rice. ", new List<string>() {"Toratilla","Rice/Beans","Veggies","Cheese"}, 8.99);
            CafeMenu pasta = new CafeMenu(4, "Pasta", "Pasta with favorite suaces and veggeis", new List<string>() {"Panne pasta","Suace","Veggies. "}, 5.99);


            _menuRepo.AddItemsToCafeMenuList(pizza);
            _menuRepo.AddItemsToCafeMenuList(sandwitch);
            _menuRepo.AddItemsToCafeMenuList(veggieWrap);
            _menuRepo.AddItemsToCafeMenuList(pasta);
        }
    }
}
