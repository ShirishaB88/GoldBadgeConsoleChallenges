using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository
{
    //Create a Menu Class with properties, constructors, and fields.
    //Plain Old C# Object ....POCO(CafeMenuObject)
    public class CafeMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }

        public List<string> Ingredients { get; set; } = new List<string>();

        //public List<string> Ingredients = new List<string>();
        public double Price { get; set; }

        //Empty constructor
        public CafeMenu()
        {

        }

        //Overload Method Another constructor
        public CafeMenu(int mealNumber, string mealName, string description, List<string> ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients.ToList();
            Price = price;


        }
    }

}
