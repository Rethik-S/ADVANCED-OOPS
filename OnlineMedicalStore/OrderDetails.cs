using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    //enum
    public enum OrderStatus { Purchased, Cancelled }
    public class OrderDetails
    {
        //field

        /// <summary>
        /// s_orderID field used to increment a OrderID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        private static int s_orderID = 2000;


        //auto property

        /// <summary>
        /// OrderID Property used to hold a  Order ID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public string OrderID { get; }//read only property

         /// <summary>
        /// UserID Property used to hold a  Order UserID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// MedicineID Property used to hold a  Order MedicineID of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public string MedicineID { get; set; }

        /// <summary>
        /// MedicineCount Property used to hold a  Order Medicine Count of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public int MedicineCount { get; set; }
         /// <summary>
        /// TotalPrice Property used to hold a  Order Total Price of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public double TotalPrice { get; set; }
        /// <summary>
        /// OrderDate Property used to hold a  Order  Date of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// OrderStatus Property used to hold a  Order status of the instance of <see cref="OrderDetails"/>
        /// </summary>
        public OrderStatus OrderStatus { get; set; }


        //constructor

        /// <summary>
        /// Constructor OrderDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="userID">userID used to store data in the associated property</param>
        /// <param name="medicineID">medicineID used to store data in the associated property</param>
        /// <param name="medicineCount">medicineCount used to store data in the associated property</param>
        /// <param name="totalPrice">totalPrice used to store data in the associated property</param>
        /// <param name="orderDate">orderDate used to store data in the associated property</param>
        /// <param name="orderStatus">orderStatus used to store data in the associated property</param>
        public OrderDetails(string userID, string medicineID, int medicineCount, double totalPrice, DateTime orderDate, OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;

            UserID = userID;
            MedicineID = medicineID;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
        }

        public OrderDetails(string order)
        {
            string[] values = order.Split(",");
            s_orderID = int.Parse(values[0].Remove(0, 3));
            OrderID = values[0];
            UserID = values[1];
            MedicineID = values[2];
            MedicineCount = int.Parse(values[3]);
            TotalPrice = double.Parse(values[4]);
            OrderDate = DateTime.ParseExact(values[5], "dd/MM/yyyy", null);
            OrderStatus = Enum.Parse<OrderStatus>(values[6]);
        }
    }
}