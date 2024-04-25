using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreApplication
{
    public class OrderDetails
    {
        // <summary>
        /// s_orderID field used to increment a OrderID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        private static int s_orderID = 4000;

        /// <summary>
        /// OrderID Property used to hold a  Order ID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public string OrderID { get; }
        /// <summary>
        /// BookingID Property used to hold a  Order BookingID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public string BookingID { get; set; }
        /// <summary>
        /// ProductID Property used to hold a  Order ProductID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// PurchaseCount Property used to hold a  Order Purchase Count of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public int PurchaseCount { get; set; }
        /// <summary>
        /// PriceOfOrder Property used to hold a  Order Price Of Order of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public double PriceOfOrder { get; set; }


        /// <summary>
        /// Constructor OrderDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="bookingID">bookingID used to store data in the associated property</param>
        /// <param name="productID">productID used to store data in the associated property</param>
        /// <param name="purchaseCount">purchaseCount used to store data in the associated property</param>
        /// <param name="priceOfOrder">priceOfOrder used to store data in the associated property</param>
        public OrderDetails(string bookingID, string productID, int purchaseCount, double priceOfOrder)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;

            BookingID = bookingID;
            ProductID = productID;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }

         public OrderDetails(string order)
        {
            string[] values = order.Split(",");

            s_orderID = int.Parse(values[0].Remove(0, 3));
            OrderID = values[0];
            BookingID = values[1];
            ProductID = values[2];
            PurchaseCount = int.Parse(values[3]);
            PriceOfOrder = double.Parse(values[4]);
        }



    }
}