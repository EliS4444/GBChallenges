using _03_KomodoClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoClaims_UI
{
    public class Program_UI
    {
        private ClaimRepo _repo = new ClaimRepo();
        public void Run()
        {
            SeedClaims();
            Menu();
        } 
        //testing
        private void SeedClaims()
        {
            Claim claim1 = new Claim(1,
               ClaimType.Car,
               "Car accident on 465",
               400.00,
               new DateTime(2018, 4, 25),
               new DateTime(2018, 4, 27));
            Claim claim2 = new Claim(02,
                ClaimType.Home,
                "House fire in kitchen",
                4000.00,
                new DateTime(2018, 4, 11),
                new DateTime(2018, 4, 12));
            Claim claim3 = new Claim(03,
                ClaimType.Theft,
                "Stolen pancakes",
                4.00,
                new DateTime(2018, 4, 27),
                new DateTime(2018, 6, 18));

            _repo.AddClaim(claim1);
            _repo.AddClaim(claim2);
            _repo.AddClaim(claim3);
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("<---> Main Menu <--->");
                Console.WriteLine("1> See all claims");
                Console.WriteLine("2> Take care of next claim");
                Console.WriteLine("3> Enter a new claim");
                Console.WriteLine("4> Exit");
                Console.WriteLine();
                Console.WriteLine("Please enter the number for a menu to continue");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        break;
                }

            }
        }
        public void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> allClaims = _repo.GetAllClaims();
            Console.WriteLine("{ 0,-10} { 1,6} { 2,-25} { 3,-12} { 4,15} { 5,12} { 6,10}", "ClaimID", "Type", "Description", "ClaimAmout", "DateOfIncident", "DateOfClaim", "IsValid");
            foreach (Claim claim in allClaims)
            {
                Console.WriteLine("{0,-10} {1,6}    {2,-25}  ${3,-12:N2} {4,-15} {5,-15} {6,6}", claim.ClaimID, claim.Type, claim.Description, claim.ClaimAmount, claim.DateOfIncident.ToString("MM/dd/yy"), claim.DateOfClaim.ToString("MM/dd/yy"), claim.IsValid);
            }
            Console.WriteLine();
            Console.WriteLine("Press any keey to return to main menu.");
            Console.WriteLine();
        }
        public void NextClaim()
        {
            Console.Clear();
            Console.WriteLine(" <--> Process Claim <-->");
            Claim claim = new Claim();
            claim = _repo.PeekClaim();
            Console.WriteLine($"Claim ID          :     {claim.ClaimID}");
            Console.WriteLine($"Claim Type        :     {claim.Type}");
            Console.WriteLine($"Claim Description :     {claim.Description}");
            Console.WriteLine($"Claim Amount      :     ${claim.ClaimAmount:N2}");
            Console.WriteLine($"Date of Incident  :     {claim.DateOfIncident.ToString("MM/dd/yy")}");
            Console.WriteLine($"Claim ID          :     {claim.DateOfClaim.ToString("MM/dd/yy")}");
            Console.WriteLine($"Is Claim Valid    :     {claim.IsValid}");
            Console.WriteLine();
            Console.WriteLine("Do you want to process this claim now? (Y/N)");
            string processClaim = Console.ReadLine();
            if (processClaim.ToLower() == "y")
            {
                bool dequeueSuccess = _repo.DequeueClaim();
                if (dequeueSuccess == true)
                {
                    Console.WriteLine("Claim successfully removed from queue. \nPress any key to return to main menu.");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong processing claim. \nPress any key to return to main menu.");
                }
                Console.ReadKey();
            }

        }

        public void NewClaim()
        {
            Claim claim = new Claim();

            bool looper = true;
            while (looper)
            {
                Console.Clear();
                Console.WriteLine("=-=- Add Claim -=-=");
                Console.WriteLine();
                Console.WriteLine("Enter Claim ID:");
                claim.ClaimID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Select Claim Type:");
                Console.WriteLine("1> Car");
                Console.WriteLine("2> Home");
                Console.WriteLine("3> Theft");
                bool typeSelectLoop = true;
                string eventType = "1";
                while (typeSelectLoop)
                {
                    eventType = Console.ReadLine();
                    if (eventType == "1" || eventType == "2" || eventType == "3")
                    {
                        typeSelectLoop = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection. 1,2, or 3");
                    }
                }
                claim.Type = (ClaimType)int.Parse(eventType);
                Console.WriteLine("Enter claim description:");
                claim.Description = Console.ReadLine();
                Console.WriteLine("Enter Amount of Claim:");
                string claimAmount = Console.ReadLine();

                if (claimAmount[0] == '$')
                {
                    claimAmount = claimAmount.Trim('$');
                }
                claim.ClaimAmount = Convert.ToDouble(claimAmount);
                DateTime date = new DateTime();
                bool dateLoop = false;
                while (!dateLoop)
                {
                    Console.WriteLine("Enter the date of incident (MM/DD/YYYY):");
                    string dateString = Console.ReadLine();
                    dateLoop = DateTime.TryParse(dateString, out date);

                }
                claim.DateOfIncident = date;
                dateLoop = false;
                while (!dateLoop)
                {
                    Console.WriteLine("Enter the date of claim (MM/DD/YYYY):");
                    string dateString = Console.ReadLine();
                    dateLoop = DateTime.TryParse(dateString, out date);
                }
                claim.DateOfClaim = date;

                if (claim.IsValid == true)
                {
                    Console.WriteLine("This claim is valid.");
                }
                else
                {
                    Console.WriteLine("This claim is invalid.");
                }
                Console.Clear();
                Console.WriteLine("=-=- Add Claim -=-=");
                Console.WriteLine();
                Console.WriteLine($"Claim ID          :     {claim.ClaimID}");
                Console.WriteLine($"Claim Type        :     {claim.Type}");
                Console.WriteLine($"Claim Description :     {claim.Description}");
                Console.WriteLine($"Claim Amount      :     ${claim.ClaimAmount:N2}");
                Console.WriteLine($"Date of Incident  :     {claim.DateOfIncident.ToString("MM/dd/yy")}");
                Console.WriteLine($"Claim ID          :     {claim.DateOfClaim.ToString("MM/dd/yy")}");
                Console.WriteLine($"Is Claim Valid    :     {claim.IsValid}");
                Console.WriteLine();
                Console.WriteLine("Does all of this look correct? Press Y to add to the Queue, press N to start over.");
                string correct = Console.ReadLine();
                if (correct.ToLower() == "y")
                {
                    looper = false;
                }

            }
            bool wasAdded = _repo.AddClaim(claim);

            if (wasAdded == true)
            {
                Console.WriteLine("New claim added to the queue.");
                Console.WriteLine("Press any key to Continue.");
            }
            else
            {
                Console.WriteLine("Oops. Something went wrong. Your claim was not added.  Please Try Again");
                Console.WriteLine("Press any key to continue.");
            }

            Console.ReadKey();
        }


    }
}
