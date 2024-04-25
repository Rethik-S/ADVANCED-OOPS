using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public static class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("MovieTicketBooking"))
            {
                Directory.CreateDirectory("MovieTicketBooking");
            }

            if (!File.Exists("MovieTicketBooking/UserDetails.csv"))
            {
                File.Create("MovieTicketBooking/UserDetails.csv").Close();
            }

            if (!File.Exists("MovieTicketBooking/BookingDetails.csv"))
            {
                File.Create("MovieTicketBooking/BookingDetails.csv").Close();
            }

            if (!File.Exists("MovieTicketBooking/TheatreDetails.csv"))
            {
                File.Create("MovieTicketBooking/TheatreDetails.csv").Close();
            }

            if (!File.Exists("MovieTicketBooking/MovieDetails.csv"))
            {
                File.Create("MovieTicketBooking/MovieDetails.csv").Close();
            }

            if (!File.Exists("MovieTicketBooking/ScreeningDetails.csv"))
            {
                File.Create("MovieTicketBooking/ScreeningDetails.csv").Close();
            }
        }

        // public static void ReadFromCSV()
        // {
        //     string[] users = File.ReadAllLines("MovieTicketBooking/UserDetails.csv");
        //     foreach(string user in users)
        //     {
        //         UserDetails userDetails = new UserDetails(user);
        //         Program.userDetailsList.Add(userDetails);
        //     }
        //     string[] users = File.ReadAllLines("MovieTicketBooking/BookingDetails.csv");
        //     foreach(string user in users)
        //     {
        //         UserDetails userDetails = new UserDetails(user);
        //         Program.userDetailsList.Add(userDetails);
        //     }
        //     string[] users = File.ReadAllLines("MovieTicketBooking/TheatreDetails.csv");
        //     foreach(string user in users)
        //     {
        //         UserDetails userDetails = new UserDetails(user);
        //         Program.userDetailsList.Add(userDetails);
        //     }
        //     string[] users = File.ReadAllLines("MovieTicketBooking/MovieDetails.csv");
        //     foreach(string user in users)
        //     {
        //         UserDetails userDetails = new UserDetails(user);
        //         Program.userDetailsList.Add(userDetails);
        //     }
        //     string[] users = File.ReadAllLines("MovieTicketBooking/ScreeningDetails.csv");
        //     foreach(string user in users)
        //     {
        //         UserDetails userDetails = new UserDetails(user);
        //         Program.userDetailsList.Add(userDetails);
        //     }
        // }
        public static void WriteToCSV()
        {
            //user details
            string[] users = new string[Program.userDetailsList.Count];
            for (int i = 0; i < Program.userDetailsList.Count; i++)
            {
                users[i] = $"{Program.userDetailsList[i].UserID},{Program.userDetailsList[i].WalletBalance},{Program.userDetailsList[i].Name},{Program.userDetailsList[i].Age},{Program.userDetailsList[i].PhoneNumber}";
            }

            File.WriteAllLines("MovieTicketBooking/UserDetails.csv", users);

            //booking details
            string[] bookings = new string[Program.bookingDetailsList.Count];
            for (int i = 0; i < Program.bookingDetailsList.Count; i++)
            {
                bookings[i] = $"{Program.bookingDetailsList[i].BookingID},{Program.bookingDetailsList[i].UserID},{Program.bookingDetailsList[i].MovieID},{Program.bookingDetailsList[i].TheatreID},{Program.bookingDetailsList[i].SeatCount},{Program.bookingDetailsList[i].TotalAmount},{Program.bookingDetailsList[i].BookingStatus}";
            }

            File.WriteAllLines("MovieTicketBooking/BookingDetails.csv", bookings);

            //theater details
            string[] theaters = new string[Program.theatreDetailsList.Count];
            for (int i = 0; i < Program.theatreDetailsList.Count; i++)
            {
                theaters[i] = $"{Program.theatreDetailsList[i].TheatreID},{Program.theatreDetailsList[i].TheatreName},{Program.theatreDetailsList[i].TheatreLocation}";
            }
            File.WriteAllLines("MovieTicketBooking/TheatreDetails.csv", theaters);

            //movie details
            string[] movies = new string[Program.movieDetailsList.Count];
            for (int i = 0; i < Program.movieDetailsList.Count; i++)
            {
                movies[i] = $"{Program.movieDetailsList[i].MovieID},{Program.movieDetailsList[i].MovieName},{Program.movieDetailsList[i].Language}";
            }

            File.WriteAllLines("MovieTicketBooking/MovieDetails.csv", movies);

            //screening detaails
            string[] screenings = new string[Program.screeningDetailsList.Count];
            for (int i = 0; i < Program.screeningDetailsList.Count; i++)
            {
                screenings[i] = $"{Program.screeningDetailsList[i].MovieID},{Program.screeningDetailsList[i].TheatreID},{Program.screeningDetailsList[i].NoOfSeats},{Program.screeningDetailsList[i].TicketPrice}";
            }

            File.WriteAllLines("MovieTicketBooking/ScreeningDetails.csv", screenings);



        }
    }
}