using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class CartItem
    {
        /*
            •	ItemID (Auto - ITID101) 
            •	OrderID
            •	FoodID
            •	OrderPrice
            •	OrderQuantity
        */

        //field
        private static int s_itemID=100;


        //Auto Property
        public string ItemID { get; }//read only property
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public double OrderPrice { get; set; }
        public int OrderQuantity { get; set; }


        //Constructor
        public CartItem(string orderID, string foodID, double orderPrice, int orderQuantity)
        {
            //auto incrementation
            s_itemID++;
            ItemID="ITID"+s_itemID;
            OrderID = orderID;
            FoodID = foodID;
            OrderPrice = orderPrice;
            OrderQuantity = orderQuantity;
        }
    }
}