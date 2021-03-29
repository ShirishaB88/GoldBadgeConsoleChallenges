using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleChallenges
{
    public class ProgramUI
    {
        //Method that runs/starts the application
        public void Run()
        {
            Menu();

        }

        private void Menu()
        {


            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                //Display the options to users
                Console.WriteLine("Enter the number of the option you would like to select:\n" +
                    "1: Show all the Items in the cafe Menu" +
                    "2: Create new items on the Menu \n" +
                    "3: Find the item by meal name \n" +
                    "4: Find the items by meal number \n" +
                    "5: Delete the existing item from Menu \n" +
                    "6: Exit");

                //Get the Users input

                string userInput = System.Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Show all the items in the Menu
                        break;
                    case "2":
                        //Create new items on the Menu
                        break;
                    case "3":
                        //Find the item by meal name
                        break;
                    case "4":
                        //Find the items by meal number
                        break;
                    case "5":
                        //Delete the existing item from Menu
                        break;
                    case "6":
                        //Exit
                        break;
                    default:
                        System.Console.WriteLine("Please enter a valid number");
                        break;

                }




            }



            //Evaluate the users input and act according to it

        }
    }
}
