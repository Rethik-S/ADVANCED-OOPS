using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class FoodDetails
    {
        //field
        private static int s_foodID = 2000;



        //Auto property
        public string FoodID { get; }//read only property
        public string FoodName { get; set; }
        public double PricePerQuantity { get; set; }
        public int QuantityAvailable { get; set; }

        //constructor
        public FoodDetails(string foodName, double pricePerQuantity, int quantityAvailable)
        {
            //Auto Incrementation
            s_foodID++;
            FoodID = "FID" + s_foodID;

            FoodName = foodName;
            PricePerQuantity = pricePerQuantity;
            QuantityAvailable = quantityAvailable;
        }

        public FoodDetails(string food)
        {
            string[] values = food.Split(",");
            s_foodID = int.Parse(values[0].Remove(0, 3));
            FoodID = values[0];
            FoodName = values[1];
            PricePerQuantity = double.Parse(values[2]);
            QuantityAvailable = int.Parse(values[3]);
        }
    }
}