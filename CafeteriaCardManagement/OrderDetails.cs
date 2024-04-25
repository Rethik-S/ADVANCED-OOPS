using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public enum OrderStatus { Default, Initiated, Ordered, Cancelled }
    public class OrderDetails
    {
        /*
            •	OrderID (Auto – OID1001)
            •	UserID
            •	OrderDate
            •	TotalPrice
            •	OrderStatus – (Default, Initiated, Ordered, Cancelled)
        */

        //field

        /// <summary>
        /// Static field s_orderID used to autoincrement OrderID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        private static int s_orderID = 1000;

        //Auto property

        /// <summary>
        /// OrderID Property used to hold a order's ID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// UserID Property used to hold a order's UserID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// OrderDate Property used to hold a order's Order Date of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// TotalPrice Property used to hold a order's TotalPrice of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// OrderStatus Property used to hold a order's OrderStatus of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public OrderStatus OrderStatus { get; set; }


        //constructor

        /// <summary>
        /// Constructor OrderDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="userID">userID parameter used to assign value to its associated property</param>
        /// <param name="orderDate">orderDate parameter used to assign value to its associated property</param>
        /// <param name="totalPrice">totalPrice parameter used to assign value to its associated property</param>
        /// <param name="orderStatus">orderStatus parameter used to assign value to its associated property</param>
        public OrderDetails(string userID, DateTime orderDate, double totalPrice, OrderStatus orderStatus)
        {
            //Auto Incrementation
            s_orderID++;
            OrderID = "OID" + s_orderID;

            UserID = userID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            OrderStatus = orderStatus;
        }


    }
}