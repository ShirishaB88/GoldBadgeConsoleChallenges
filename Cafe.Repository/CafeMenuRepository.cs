using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository
{
    //Create a MenuRepository Class that has methods needed.
    public class CafeMenuRepository
    {
        private List<CafeMenu> _listOfCafeMenuItems = new List<CafeMenu>();  //Empty field

        //Create

        public bool AddItemsToCafeMenuList(CafeMenu items)
        {
            int startingItemCount = _listOfCafeMenuItems.Count;

            _listOfCafeMenuItems.Add(items); //.Add method used to add new items to the List

            bool wasAdded = (_listOfCafeMenuItems.Count > startingItemCount) ? true : false; //ternary condition statement

            return wasAdded;



            //if (startingItemCount > _listOfCafeMenuItems.Count)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}


        }

        //Read

        public List<CafeMenu> GetCafeMenu() //ReturnType is List
        {
            return _listOfCafeMenuItems;
        }


        //Update..... We do not need this for Cafe Challenge


        //Delete
        //Delete all the exisiting Items From Menu
        public bool DeleteExistingItems(CafeMenu existingItems)
        {
          bool deleteResults =  _listOfCafeMenuItems.Remove(existingItems); //Remove mthod used for revoing all the existing items from Menu
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

            int startcount = _listOfCafeMenuItems.Count();
            _listOfCafeMenuItems.Remove(item);


            bool wasRemoved = (startcount > _listOfCafeMenuItems.Count) ? true : false;
            return wasRemoved;


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

        //getting the  items by List of ingredients

        public CafeMenu GetItemByListOFIngredients(string ingredient)
        {
            foreach (CafeMenu item in _listOfCafeMenuItems)
            {
                if (item.Ingredients.Contains(ingredient) )
                {
                    return item;
                }
            }
            return null;
        }

        //Getting the Items By Price

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
