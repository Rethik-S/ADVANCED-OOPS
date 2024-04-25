using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TravelDetails
    {
        //field
        /// <summary>
        /// Static field s_travelID used to autoincrement TravelID of the instance of <see cref="TravelDetails"/>
        /// </summary>
        private static int s_travelID = 2000;


        //Auto Property

        /// <summary>
        /// TravelID Property used to hold a User's TravelID of the instance of <see cref="TravelDetails"/>
        /// </summary>
        public string TravelID { get; }//read only property

        /// <summary>
        /// CardNumber Property used to hold a User's Card Number of the instance of <see cref="TravelDetails"/>
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// FromLocation Property used to hold a User's From Location of the instance of <see cref="TravelDetails"/>
        /// </summary>
        public string FromLocation { get; set; }

        /// <summary>
        /// ToLocation Property used to hold a User's To Location of the instance of <see cref="TravelDetails"/>
        /// </summary>
        public string ToLocation { get; set; }

        /// <summary>
        /// Date Property used to hold a User's Travel Date of the instance of <see cref="TravelDetails"/>
        /// </summary>
        public DateTime Date { get; set; }

        // <summary>
        /// TravelCost Property used to hold a User's Travel Cost of the instance of <see cref="TravelDetails"/>
        /// </summary>
        public double TravelCost { get; set; }

        //Constructor

        /// <summary>
        ///  Constructor TravelDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="cardNumber">cardNumber used to store data in the associated property</param>
        /// <param name="fromLocation">fromLocation used to store data in the associated property</param>
        /// <param name="toLocation">toLocation used to store data in the associated property</param>
        /// <param name="date">date used to store data in the associated property</param>
        /// <param name="travelCost">travelCost used to store data in the associated property</param>
        public TravelDetails(string cardNumber, string fromLocation, string toLocation, DateTime date, double travelCost)
        {
            //Auto Incrementation
            s_travelID++;
            TravelID = "TID" + s_travelID;

            CardNumber = cardNumber;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            Date = date;
            TravelCost = travelCost;
        }
        

        /// <summary>
        /// Constructor TravelDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="travel">travel used to store data in the associated property</param>
        public TravelDetails(string travel)
        {
            string[] values = travel.Split(",");
            s_travelID = int.Parse(values[0].Remove(0, 3));
            TravelID = values[0];
            CardNumber = values[1];
            FromLocation = values[2];
            ToLocation = values[3];
            Date = DateTime.ParseExact(values[4], "dd/MM/yyyy", null);
            TravelCost = double.Parse(values[5]);
        }
    }
}