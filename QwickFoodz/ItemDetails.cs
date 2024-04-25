using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class ItemDetails
    {
        //field
        private static int s_itemID = 4000;


        //Auto property
        public string ItemID { get; }//read only property
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public int PurchaseCount { get; set; }
        public double PriceOfOrder { get; set; }

        //constructor
        public ItemDetails(string orderID, string foodID, int purchaseCount, double priceOfOrder)
        {
            //Auto Incrementation
            s_itemID++;
            ItemID = "ITID" + s_itemID;

            OrderID = orderID;
            FoodID = foodID;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }

        public ItemDetails(string item)
        {
            string[] values = item.Split(",");
            s_itemID = int.Parse(values[0].Remove(0, 4));
            ItemID = values[0];
            OrderID = values[1];
            FoodID = values[2];
            PurchaseCount = int.Parse(values[3]);
            PriceOfOrder = double.Parse(values[4]);
        }

    }
}