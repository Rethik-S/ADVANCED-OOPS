using System;
using System.IO;

namespace MetroCardManagement
{
    public static class FileHandling
    {

        //create
        public static void Create()
        {
            //creating MetroCardManagement folder
            if (!Directory.Exists("MetroCardManagement"))
            {
                Console.WriteLine($"Folder created");
                Directory.CreateDirectory("MetroCardManagement");
            }

            //UserDetails file creation
            if (!File.Exists("MetroCardManagement/UserDetails.csv"))
            {
                Console.WriteLine($"Creating user details file");
                File.Create("MetroCardManagement/UserDetails.csv").Close();
            }

            //TicketFairDetails file creation
            if (!File.Exists("MetroCardManagement/TicketFairDetails.csv"))
            {
                Console.WriteLine($"Creating user details file");
                File.Create("MetroCardManagement/TicketFairDetails.csv").Close();
            }

            //TravelDetails file creation
            if (!File.Exists("MetroCardManagement/TravelDetails.csv"))
            {
                Console.WriteLine($"Creating user details file");
                File.Create("MetroCardManagement/TravelDetails.csv").Close();
            }
        }//create ends


        //ReadToCSV
        public static void ReadFromCSV()
        {

            //user details
            string[] users = File.ReadAllLines("MetroCardManagement/UserDetails.csv");
            foreach (string user in users)
            {
                UserDetails userDetails = new UserDetails(user);
                Operations.userDetailsList.Add(userDetails);
            }

            //Ticket Fair
            string[] ticketfairs = File.ReadAllLines("MetroCardManagement/TicketFairDetails.csv");
            foreach (string ticketfair in ticketfairs)
            {
                TicketFairDetails fairDetails = new TicketFairDetails(ticketfair);
                Operations.ticketFairDetailsList.Add(fairDetails);
            }

            //travelDetails
            string[] travelDetails = File.ReadAllLines("MetroCardManagement/TravelDetails.csv");
            foreach (string travelDetail in travelDetails)
            {
                TravelDetails travel = new TravelDetails(travelDetail);
                Operations.travelDetailsList.Add(travel);
            }



        }


        //WriteTOCSV
        public static void WriteToCSV()
        {
            //user details
            string[] users = new string[Operations.userDetailsList.Count];
            int userindex = 0;

            //create single string of each object
            foreach (UserDetails user in Operations.userDetailsList)
            {
                //increment index 
                users[userindex++] = $"{user.CardNumber},{user.UserName},{user.PhoneNumber},{user.Balance}";
            }

            //Write all strings in users to File
            File.WriteAllLines("MetroCardManagement/UserDetails.csv", users);


            //ticket fair details
            string[] ticketfairs = new string[Operations.ticketFairDetailsList.Count];
            int ticketIndex = 0;

            //create single string of each object
            foreach (TicketFairDetails ticketFair in Operations.ticketFairDetailsList)
            {
                //increment index 
                ticketfairs[ticketIndex++] = $"{ticketFair.TicketID},{ticketFair.FromLocation},{ticketFair.ToLocation},{ticketFair.TicketPrice}";
            }

            //Write all strings in ticketfairs to File
            File.WriteAllLines("MetroCardManagement/TicketFairDetails.csv", ticketfairs);



            //travel details
            string[] travelDetails = new string[Operations.travelDetailsList.Count];
            int travelIndex = 0;

            //create single string of each object
            foreach (TravelDetails travel in Operations.travelDetailsList)
            {
                //increment index 
                travelDetails[travelIndex++] = $"{travel.TravelID},{travel.CardNumber},{travel.FromLocation},{travel.ToLocation},{travel.Date:dd/MM/yyyy},{travel.TravelCost}";
            }


            //Write all strings in traveldetails to File
            File.WriteAllLines("MetroCardManagement/TravelDetails.csv", travelDetails);

        }//WriteToCSV ends


    }
}