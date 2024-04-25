using System;
//using System.Collections.Generic;


namespace MetroCardManagement
{
    public static class Operations
    {
        //local/global variable for user logged in

        static UserDetails currentLoggedInUser;

        //static list creation
        public static CustomList<UserDetails> userDetailsList = new CustomList<UserDetails>();
        public static CustomList<TravelDetails> travelDetailsList = new CustomList<TravelDetails>();
        public static CustomList<TicketFairDetails> ticketFairDetailsList = new CustomList<TicketFairDetails>();

        static string line = "-----------------------------------------";

        //Main menu
        public static void MainMenu()
        {
            Console.WriteLine(line);
            Console.WriteLine($"       WELCOME TO METRO CARD");
            Console.WriteLine(line);

            string mainChoice = "yes";
            do
            {
                Console.WriteLine($"Main Menu");
                Console.WriteLine();
                Console.WriteLine($"1. User Registraion\n2. User Login\n3. Exit");
                //ask user to select option
                Console.Write($"Select a Option: ");
                string mainOption = Console.ReadLine();
                switch (mainOption)
                {
                    case "1":
                        {
                            Console.WriteLine($"User Registration");
                            Console.WriteLine();

                            UserRegistraion();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine($"User Login");
                            Console.WriteLine();

                            UserLogin();
                            break;
                        }
                    case "3":
                        {
                            //exit
                            mainChoice = "no";
                            Console.WriteLine($"Application exited successfully.");

                            break;
                        }
                    default:
                        {
                            //diplay invalid option
                            Console.WriteLine($"Enter a valid Option.");
                            break;
                        }
                }

            } while (mainChoice == "yes");

        }//Main menu ends

        //User Registration
        public static void UserRegistraion()
        {
            //getting details
            Console.Write($"Enter User Name: ");
            string userName = Console.ReadLine();

            Console.Write($"Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            while (!"6789".Contains(phoneNumber[0]) || !(phoneNumber.Length == 10))
            {
                Console.WriteLine($"Enter a valid phone number");
                Console.Write($"Enter Phone Number: ");
                phoneNumber = Console.ReadLine();
            }

            Console.Write($"Enter the Amount to Deposit: ");
            double amount;
            bool isAmountValid = double.TryParse(Console.ReadLine(), null, out amount);
            while (!isAmountValid || !(amount > 0))
            {
                Console.WriteLine($"Enter a valid amount");
                Console.Write($"Enter the Amount to Deposit: ");
                isAmountValid = double.TryParse(Console.ReadLine(), null, out amount);

            }


            //create user details object
            UserDetails user = new UserDetails(userName, phoneNumber, amount);

            //Add the user to list
            userDetailsList.Add(user);

            //Display card number
            Console.WriteLine($"Registration Successfull. Your Card Number is {user.CardNumber}");

        }

        //Login
        public static void UserLogin()
        {
            //ask user the card number
            Console.Write($"Enter Card Number: ");
            string cardNumber = Console.ReadLine().ToUpper();
            bool flag = true;
            //check card number exist
            foreach (UserDetails user in userDetailsList)
            {
                if (cardNumber.Equals(user.CardNumber))
                {
                    flag = false;
                    //assign user to glbal variable
                    currentLoggedInUser = user;
                    //redirect to sub menu
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                //display in valid card number
                Console.WriteLine("the card number you entered is not a valid one");

            }
        }

        public static void SubMenu()
        {
            string subChoice = "yes";
            Console.WriteLine($"Welcome {currentLoggedInUser.UserName}");
            Console.WriteLine();
            do
            {
                Console.WriteLine($"Sub Menu");
                Console.WriteLine();


                Console.WriteLine($"1. Balance Check\n2. Recharge\n3. View Travel History\n4. Travel\n5. Exit ");
                //ask user to select a option
                Console.Write($"Select a option: ");
                string subOption = Console.ReadLine();
                switch (subOption)
                {
                    case "1":
                        {
                            Console.WriteLine($"*** Balance Check ***");
                            BalanceCheck();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine($"*** Recharge ***");
                            Recharge();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine($"*** View Travel History ***");
                            ViewTravelHistory();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine($"*** Travel ***");
                            Travel();
                            break;
                        }
                    case "5":
                        {
                            //exit
                            subChoice = "no";
                            break;
                        }
                    default:
                        {
                            //display user to enter valid option
                            Console.WriteLine($"Enter a valid option.");
                            break;
                        }
                }

            } while (subChoice == "yes");



        }//Sub menu ends


        //balance check
        public static void BalanceCheck()
        {
            //display currrent user balance
            Console.WriteLine($"Your balance is {currentLoggedInUser.Balance}");

        }//balance check ends

        //recharge
        public static void Recharge()
        {
            //ask user to enter amount
            Console.Write($"Enter the amount to recharge: ");
            double amount = double.Parse(Console.ReadLine());
            //recharge the user. display cuurent balance
            Console.WriteLine($"Your balance is {currentLoggedInUser.WalletRecharge(amount)}");

        }//recharge ends

        //view travel history
        public static void ViewTravelHistory()
        {
            bool flag = true;
            //check travel history is present
            foreach (TravelDetails travelDetails in travelDetailsList)
            {
                if (currentLoggedInUser.CardNumber.Equals(travelDetails.CardNumber))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                //display user history not exist
                Console.WriteLine($"Travel history does not exist.");

            }
            else
            {
                //display travel history
                foreach (TravelDetails travel in travelDetailsList)
                {
                    if (currentLoggedInUser.CardNumber.Equals(travel.CardNumber))
                    {
                        Console.WriteLine($"|{travel.TravelID}|{travel.CardNumber}|{travel.FromLocation}|{travel.ToLocation}|{travel.Date:dd/MM/yyyy}|{travel.TravelCost}|");
                    }

                }
            }

        }//view travel history ends	

        //Travel
        public static void Travel()
        {
            //display ticket fair details
            foreach (TicketFairDetails ticketFair in ticketFairDetailsList)
            {
                Console.WriteLine($"|{ticketFair.TicketID}|{ticketFair.FromLocation}|{ticketFair.ToLocation}|{ticketFair.TicketPrice}|");
            }

            bool flag = true;
            //ask user to enter ticket id
            Console.Write($"Enter the Ticket ID: ");
            string ticketID = Console.ReadLine().ToUpper();
            foreach (TicketFairDetails ticketFairDetails in ticketFairDetailsList)
            {
                //check ticket is valid
                if (ticketID.Equals(ticketFairDetails.TicketID))
                {
                    flag = false;
                    if (ticketFairDetails.TicketPrice > currentLoggedInUser.Balance)
                    {
                        //display insufficient balance
                        Console.WriteLine($"Insufficient balance. PLease Recharge");
                        //redirect to recharge
                        Recharge();
                    }
                    else
                    {

                        //deduct ticket price from user wallet
                        currentLoggedInUser.DeductBalance(ticketFairDetails.TicketPrice);
                        //create travel details object
                        TravelDetails travelDetails = new TravelDetails(currentLoggedInUser.CardNumber, ticketFairDetails.FromLocation, ticketFairDetails.ToLocation, DateTime.Now, ticketFairDetails.TicketPrice);
                        //add travel details to list
                        travelDetailsList.Add(travelDetails);

                        //diplay ticket booked
                        Console.WriteLine($"Ticket booked successfully. tour travel id is {travelDetails.TravelID}");

                    }
                    break;
                }
            }
            if (flag)
            {
                //display invalid ticket id
                Console.WriteLine($"Invalid ticket id");
            }
        }//travel ends


        //Default data
        public static void DefaultData()
        {
            UserDetails user1 = new UserDetails("Ravi", "9848812345", 1000);
            UserDetails user2 = new UserDetails("Baskaran", "9948854321", 1000);

            userDetailsList.Add(user1);
            userDetailsList.Add(user2);

            TravelDetails travel1 = new TravelDetails("CMRL1001", "Airport", "Egmore", new DateTime(2023, 10, 10), 55);
            TravelDetails travel2 = new TravelDetails("CMRL1001", "Egmore", "Koyambedu", new DateTime(2023, 10, 10), 32);
            TravelDetails travel3 = new TravelDetails("CMRL1002", "Alandur", "Koyambedu", new DateTime(2023, 11, 10), 25);
            TravelDetails travel4 = new TravelDetails("CMRL1002", "Egmore", "Thirumangalam", new DateTime(2023, 11, 10), 25);

            travelDetailsList.AddRange(new CustomList<TravelDetails> { travel1, travel2, travel3, travel4 });


            TicketFairDetails ticketFair1 = new TicketFairDetails("Airport", "Egmore", 55);
            TicketFairDetails ticketFair2 = new TicketFairDetails("Airport", "Koyambedu", 25);
            TicketFairDetails ticketFair3 = new TicketFairDetails("Alandur", "Koyambedu", 25);
            TicketFairDetails ticketFair4 = new TicketFairDetails("Koyambedu", "Egmore", 32);
            TicketFairDetails ticketFair5 = new TicketFairDetails("Vadapalani", "Egmore", 45);
            TicketFairDetails ticketFair6 = new TicketFairDetails("Arumbakkam", "Egmore", 25);
            TicketFairDetails ticketFair7 = new TicketFairDetails("Vadapalani", "Koyambedu", 25);
            TicketFairDetails ticketFair8 = new TicketFairDetails("Arumbakkam", "Koyambedu", 16);

            ticketFairDetailsList.AddRange(new CustomList<TicketFairDetails> { ticketFair1, ticketFair2, ticketFair3, ticketFair4, ticketFair5, ticketFair6, ticketFair7, ticketFair8 });


        }//Default data ends
    }
}