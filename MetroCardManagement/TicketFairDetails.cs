using System;
using System.Collections.Generic;

namespace MetroCardManagement
{
    public class TicketFairDetails
    {
        //field
        /// <summary>
        /// Static field s_ticketID used to autoincrement TicketID of the instance of <see cref="TicketFairDetails"/>
        /// </summary>
        private static int s_ticketID = 3000;


        //Auto property
        /// <summary>
        /// TicketID Property used to hold a Ticket ID of the instance of <see cref="TicketFairDetails"/>
        /// </summary>
        public string TicketID { get; }///read only property
        /// <summary>
        /// FromLocation Property used to hold a Ticket From Location of the instance of <see cref="TicketFairDetails"/>
        /// </summary>
        public string FromLocation { get; set; }
         /// <summary>
        /// ToLocation Property used to hold a Ticket To Location of the instance of <see cref="TicketFairDetails"/>
        /// </summary>
        public string ToLocation { get; set; }
         /// <summary>
        /// TicketPrice Property used to hold a Ticket Price of the instance of <see cref="TicketFairDetails"/>
        /// </summary>
        public double TicketPrice { get; set; }

        /// <summary>
        /// Constructor TicketFairDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="fromLocation">fromLocation used to store data in the associated property</param>
        /// <param name="toLocation">toLocation used to store data in the associated property</param>
        /// <param name="ticketPrice">ticketPrice used to store data in the associated property</param>
        public TicketFairDetails(string fromLocation, string toLocation, double ticketPrice)
        {
            //Auto Incrementation
            s_ticketID++;
            TicketID = "MR" + s_ticketID;

            FromLocation = fromLocation;
            ToLocation = toLocation;
            TicketPrice = ticketPrice;
        }

        /// <summary>
        /// Constructor TicketFairDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="ticketfair">ticketfair used to store data in the associated property</param>
        public TicketFairDetails(string ticketfair)
        {
            string[] values = ticketfair.Split(",");
            s_ticketID = int.Parse(values[0].Remove(0, 2));
            TicketID = values[0];
            FromLocation = values[1];
            ToLocation = values[2];
            TicketPrice = double.Parse(values[3]);
        }
    }
}