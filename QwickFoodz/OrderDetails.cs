using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    //enum
    public enum OrderStatus { Default, Initiated, Ordered, Cancelled }
    public class OrderDetails
    {
        //field
        private static int s_orderID = 3000;


        //Auto property
        public string OrderID { get; }//read only property
        public string CustomerID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateOfOrder { get; set; }
        public OrderStatus OrderStatus { get; set; }

        //constructor
        public OrderDetails(string customerID, double totalPrice, DateTime dateOfOrder, OrderStatus orderStatus)
        {
            //Auto Incrementation
            s_orderID++;
            OrderID = "OID" + s_orderID;

            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfOrder = dateOfOrder;
            OrderStatus = orderStatus;
        }
        public OrderDetails(string order)
        {
            string[] values = order.Split(",");
            s_orderID = int.Parse(values[0].Remove(0, 3));
            OrderID = values[0];
            CustomerID = values[1];
            TotalPrice = double.Parse(values[2]);
            DateOfOrder = DateTime.ParseExact(values[3], "dd/MM/yyyy", null);
            OrderStatus = Enum.Parse<OrderStatus>(values[4]);
        }
    }
}