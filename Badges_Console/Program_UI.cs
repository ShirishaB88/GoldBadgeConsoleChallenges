using Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    public class Program_UI
    {
        private BadgesRepository _badgeRepo = new BadgesRepository();

        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            bool continuetoRun = true;

            while (continuetoRun)
            {
                Console.Clear();

                Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                    "1: Add a badge   \n" +
                    "2: Edit a badge    \n" +
                    "3: List all Badges    \n" +
                    "4: Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateANewBadge();
                        break;
                    case "2":
                        UpdateExistingBadge();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "4":
                        continuetoRun = false;
                        break;

                    default:
                        Console.WriteLine("Please Enter a Valid Menu options\n" +
                            "Press any key to continue.......");
                        break;
                }

            }

        }

        private void UpdateExistingBadge()
        {
            Console.Clear();

            Console.WriteLine("Please input badge Key number: ");
            int userInputBadgeKey = int.Parse(Console.ReadLine());

            Badges oldBadge = _badgeRepo.GetBadgesByTheKey(userInputBadgeKey);

            Badges newBadge = new Badges();

            Console.WriteLine("What is the badge number to update? ");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine($"{newBadge.BadgeID} has Access to: ");
            foreach (var door in oldBadge.BadgeDoors)
            {
                if(door != null)
                {
                    Console.WriteLine(door);
                }
                
            }


            Console.WriteLine("What Would you like to Do \n" +
                "1. Remove BadgeDoor\n" +
                "2. Add BadgeDoor ");
            string addOrRemove = Console.ReadLine();

            switch(addOrRemove)
            {
                case "1":
                    Console.WriteLine("Which Door would you like to remove? ");
                    string doorToremove = Console.ReadLine();
                    oldBadge.BadgeDoors.Remove(doorToremove);
                    newBadge.BadgeDoors = oldBadge.BadgeDoors;


                    Console.WriteLine($"{doorToremove} Door Removed \n" +
                        $"{newBadge.BadgeID} has Access to: ");
                   
                    foreach (var door in newBadge.BadgeDoors)
                    {
                        if (door != null)
                        {
                            Console.WriteLine(door);
                        }
                        else
                        {
                            Console.WriteLine("No doors to remove");
                        }

                    }

                    break;

                case "2":

                    bool hasDoorsToAdd = true;

                    while (hasDoorsToAdd)
                    {
                        Console.WriteLine("Do you have a door that it needs Add Enter (y/n) ");
                        string userInput = Console.ReadLine().ToLower();
                        if (userInput == "y")
                        {
                            Console.WriteLine("Enter the Badge Door need to Add: ");
                            string badgeDoor = Console.ReadLine();
                            oldBadge.BadgeDoors.Add(badgeDoor);
                            Console.WriteLine($"{newBadge.BadgeID} has Access to: ");

                           foreach (var door in oldBadge.BadgeDoors)
                            {
                                if (door != null)
                                {
                                    Console.WriteLine(door);
                                }

                            }
                        }
                        else
                        {
                            hasDoorsToAdd = false;
                        }

                    }

                    break;



            }
            

            bool isSuccessful = _badgeRepo.UpdateExistingBadges(userInputBadgeKey, newBadge);

            if (isSuccessful)
            {
                Console.WriteLine("Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Failed");
            }


            Console.ReadKey();
        }

        public void CreateANewBadge()
        {
            Console.Clear();

            Badges newBadges = new Badges();

            Console.WriteLine("What is the number on the badge: ");
            newBadges.BadgeID = int.Parse(Console.ReadLine());



            bool hasDoorsToAdd = true;

            while (hasDoorsToAdd)
            {
                Console.WriteLine("Do you have a door that it needs access to: Enter (y/n) ");
                string userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    Console.WriteLine("Enter the Badge Door need to Add: ");
                    string badgeDoor = Console.ReadLine();
                    newBadges.BadgeDoors.Add(badgeDoor);
                    
                }
                else
                {
                    hasDoorsToAdd = false;
                }

            }

            _badgeRepo.AddNewBadgesToTheDictinary(newBadges);
        }

       

        public  void ShowAllBadges()
        {
            Console.Clear();

            Dictionary<int, Badges> badgesToShow = _badgeRepo.GetAllBadges();
            foreach (var badge in badgesToShow)
            {
                DisplayBadges(badge.Value);


            }

            Console.ReadKey();

        }

        private void DisplayBadges(Badges badge)
        {

            Console.WriteLine($"Badge# {badge.BadgeID}");
            foreach (var door in badge.BadgeDoors)
            {
                Console.WriteLine($"Door Access {door} ");
            }

        }

        private void SeedList()
        {
            Badges badge1 = new Badges(12345, new List<string>() { "A7"});
            Badges badge2 = new Badges(22345, new List<string>() { "A1","A4","B1","B2" });
            Badges badge3 = new Badges(32345, new List<string>() { "A4", "A5" });
            Badges badge4 = new Badges(42345, new List<string>() { "A7", "A1"});

            _badgeRepo.AddNewBadgesToTheDictinary(badge1);
            _badgeRepo.AddNewBadgesToTheDictinary(badge2);
            _badgeRepo.AddNewBadgesToTheDictinary(badge3);
            _badgeRepo.AddNewBadgesToTheDictinary(badge4);

        }


    }


}








    

