using Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_UI
{
    public class Program_UI
    {
        private ClaimsRepoistory _claimsRepo = new ClaimsRepoistory();

        public void Run()
        {
            seedItems();
            Menu();
        }

        private void Menu()
        {
            bool continueToRun = true;

            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select the Menu Options \n" +
                    "1: See all claims \n" +
                    "2: Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllTheClaims();
                        break;
                   
                    case "2":
                        ShowTheNextClaimInTheQueue();
                        break;
                   
                    case "3":
                        CreateNewClaimInTheQueue();
                        break;
                    
                    case "4":
                        continueToRun = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number from Menu \n" +
                            "Press any key to continue.......");
                        Console.ReadKey();
                        break;

                }
            }
        }

        private void CreateNewClaimInTheQueue()
        {
            Console.Clear();
            Claims claimItem = new Claims();

            Console.WriteLine("Start Adding the New Claim to the Queue");


            //claimID
            Console.WriteLine("Please Enter A ClaimID");
            claimItem.ClaimID = int.Parse(Console.ReadLine());

            //typeOfClaim
            Console.WriteLine("Please Enter Type of Claim: \n" +
                "1: Car \n" +
                "2: Home\n" +
                "3: Theft\n");

            string typeOfClaim = Console.ReadLine();

            switch (typeOfClaim)
            {
                case "1":
                    claimItem.TypeOfClaim = ClaimType.Car;
                    break;
                case "2":
                    claimItem.TypeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    claimItem.TypeOfClaim = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please Enter a Valid Number for Type Of Claims");
                    Console.ReadKey();
                    break;
            }

            //description
            Console.WriteLine("Pelase Enter Claim Description");
            claimItem.Description = Console.ReadLine();

            //claimAmount
            Console.WriteLine("Please Enter Claim Amount");
            claimItem.ClaimAmount = double.Parse(Console.ReadLine());

            //dateOfIncident
            Console.WriteLine("Please Enter Date Of Date Of Incident ");
            claimItem.DateOfIncident = DateTime.Parse(Console.ReadLine());

            //dateOfClaim
            Console.WriteLine("Please Enter Date Of Date Of Claim ");
            claimItem.DateOfClaim = DateTime.Parse(Console.ReadLine());


            TimeSpan timeSpan = claimItem.DateOfClaim - claimItem.DateOfIncident;
            int daysToClaim = Convert.ToInt32(timeSpan.TotalDays);

            //IsValid
            Console.WriteLine("This Claim is: ");
            if (daysToClaim > 30)
            {
               
                Console.WriteLine("Is Not Valid"); 
            }
            else
            {
                Console.WriteLine("Is Valid");
            }

            Console.ReadKey();

        }
            
        public void ShowAllTheClaims()
        {
            Console.Clear();
            Queue<Claims> claimsQueue = _claimsRepo.GetAllClaims();
            foreach (Claims claimItem in claimsQueue)
            {
                DisplayClaims(claimItem);
            }
           
            Console.ReadKey();

        }

        public void ShowTheNextClaimInTheQueue()
        {
            Console.Clear();

            Claims claimItem = _claimsRepo.ViewNextClaim();

            if (claimItem== null)
            {
                Console.WriteLine("Claim does not exist");
            }
            else
            {
                DisplayClaims(claimItem);

                Console.WriteLine("Do you want to process this claim: y/n");

                string userInput = Console.ReadLine().ToLower();

                if (userInput == "y")
                {
                    _claimsRepo.ProcessClaim();
                }

                else
                {
                    Menu();
                }

    
            }

            Console.ReadKey();

        }

        private void DisplayClaims(Claims claimItem)
        {
          
            Console.WriteLine($"ClaimID: {claimItem.ClaimID}\n" +
                $"Type OfClaim: {claimItem.TypeOfClaim}\n" +
                $"Description:{claimItem.Description}\n" +
                $"Claim Amount: {claimItem.ClaimAmount}\n" +
                $"Date Of Incident: {claimItem.DateOfIncident}\n" +
                $"Date Of Claim: {claimItem.DateOfClaim} \n" +
                $"IsValid: {claimItem.IsValid}"); 

            
        }

        private void seedItems()
        {
            Claims claimItem1 = new Claims(1, ClaimType.Car, "Car accident on 464.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claims claimItem2 = new Claims(2, ClaimType.Car, "Car accident on 465.",400.00,new DateTime(2018,4,25),new DateTime(2018,4,27), true);
            Claims claimItem3 = new Claims(3, ClaimType.Home, "House fire in kitchen.",4000.00, new DateTime(2018,4,11),new DateTime(2018,4,12), true);
            Claims claimItem4 = new Claims(4, ClaimType.Theft, "Stolen pancakes.", 4.00,new DateTime(2018,4,27),new DateTime(2018,6,01), false);

            _claimsRepo.AddClaimsToTheQueue(claimItem1);
            _claimsRepo.AddClaimsToTheQueue(claimItem2);
            _claimsRepo.AddClaimsToTheQueue(claimItem3);
            _claimsRepo.AddClaimsToTheQueue(claimItem4);
        }


    }
}
