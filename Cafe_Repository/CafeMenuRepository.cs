using Cafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    //Create a MenuRepository Class that has methods needed.
    public class CafeMenuRepository
    {
        private List<CafeMenu> _listOfCafeMenuItems = new List<CafeMenu>();  //Empty field

        //Create

        public bool AddItemsToCafeMenuList(CafeMenu items)
        {
            //int startingItemCount = _listOfCafeMenuItems.Count;

            _listOfCafeMenuItems.Add(items); //.Add method used to add new items to the List

            //bool wasAdded = (_listOfCafeMenuItems.Count > startingItemCount) ? true : false; //ternary condition statement

            return true; 


        }

        //Read

        public List<CafeMenu> GetCafeMenu() //ReturnType is List
        {
            return _listOfCafeMenuItems;
        }

        //update
        public bool UpdateCafeMenuItems(int mealNumber, CafeMenu newCafeMenu)
        {
            CafeMenu oldCafeMenu = GetMenuItemsByMealNumber(mealNumber);

            if(oldCafeMenu != null)
            {
                oldCafeMenu.MealNumber = newCafeMenu.MealNumber;
                oldCafeMenu.MealName = newCafeMenu.MealName;
                oldCafeMenu.Description = newCafeMenu.Description;
                oldCafeMenu.Ingredients = newCafeMenu.Ingredients;
                oldCafeMenu.Price = newCafeMenu.Price;
                return true;
            }
            else
            {
                return false;
            }


        }

       

        //Delete
        //Delete all the exisiting Items From Menu
        public bool DeleteExistingItems(CafeMenu existingItems)
        {
          bool deleteResults =  _listOfCafeMenuItems.Remove(existingItems); //Remove method used for revoing all the existing items from Menu
            return deleteResults;
        }

        //Delete the item by GettingByMealName method
        public bool RemoveItemFromCafeMenu(string mealName)
        {
            CafeMenu item = GetMenuItemByMealName(mealName);

            if (item == null)
            {
                return false;
            }

            _listOfCafeMenuItems.Remove(item);
            return true; 


            //int startcount = _listOfCafeMenuItems.Count();
            //bool wasRemoved = (startcount > _listOfCafeMenuItems.Count) ? true : false;


        }



        //Helper Methods

        //Getting the Items by MealName
        public CafeMenu GetMenuItemByMealName(string mealName)
        {

            foreach (CafeMenu item in _listOfCafeMenuItems)
            {
                if (item.MealName.ToLower() == mealName.ToLower())
                {
                    return item;
                }
            }

            return null;

        }


        //Getting the  Items By Meal Number
        public CafeMenu GetMenuItemsByMealNumber(int mealNumber)
        {
            foreach (CafeMenu item in _listOfCafeMenuItems)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }

        //Getting the items by Meal Description 

        public CafeMenu GetItemsByDescription(string description)
        {
            foreach (CafeMenu item in _listOfCafeMenuItems)
            {
                if (item.Description.ToLower() == description.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        

        public CafeMenu GetItemByPrice(double price)
        {
            foreach (CafeMenu item in _listOfCafeMenuItems)
            {
                if (item.Price == price)
                {
                    return item;
                }
            }
            return null;
        }



    }
}
