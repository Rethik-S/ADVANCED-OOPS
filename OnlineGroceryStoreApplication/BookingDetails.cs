using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreApplication
{
    public enum BookingStatus { Default, Initiated, Booked, Cancelled }
    public class BookingDetails
    {
         // <summary>
        /// s_bookingID field used to increment a BookingID of the instance of <see cref="BookingDetails"/>
        /// </summary>
        private static int s_bookingID = 3000;

        /// <summary>
        /// BookingID Property used to hold a  Booking ID of the instance of <see cref="BookingDetails"/>
        /// </summary>
        public string BookingID { get; }

        /// <summary>
        /// CustomerID Property used to hold a  Customer ID of the instance of <see cref="BookingDetails"/>
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// TotalPrice Property used to hold a  Booking Total Price of the instance of <see cref="BookingDetails"/>
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// DateOfBooking Property used to hold a  Date Of Booking of the instance of <see cref="BookingDetails"/>
        /// </summary>
        public DateTime DateOfBooking { get; set; }

        /// <summary>
        /// BookingStatus Property used to hold a  Booking Status of the instance of <see cref="BookingDetails"/>
        /// </summary>
        public BookingStatus BookingStatus { get; set; }

        /// <summary>
        /// Constructor BookingDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="customerID">customerID used to store data in the associated property</param>
        /// <param name="totalPrice">totalPrice used to store data in the associated property</param>
        /// <param name="dateOfBooking">dateOfBooking used to store data in the associated property</param>
        /// <param name="bookingStatus">bookingStatus used to store data in the associated property</param>
        public BookingDetails(string customerID, double totalPrice, DateTime dateOfBooking, BookingStatus bookingStatus)
        {
            s_bookingID++;
            BookingID = "BID" + s_bookingID;

            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfBooking = dateOfBooking;
            BookingStatus = bookingStatus;
        }
        public BookingDetails(string booking)
        {
            string[] values = booking.Split(",");
            s_bookingID = int.Parse(values[0].Remove(0,3));
            BookingID = values[0];
            CustomerID = values[1];
            TotalPrice = double.Parse(values[2]);
            DateOfBooking = DateTime.ParseExact(values[3], "dd/MM/yyyy", null);
            BookingStatus = Enum.Parse<BookingStatus>(values[4]);
        }

        public void ShowBookingDetails()
        {

        }
    }
}