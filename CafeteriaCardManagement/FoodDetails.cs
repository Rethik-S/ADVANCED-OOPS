using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class FoodDetails
    {
        /*
            •	FoodID (Auto - FID101)
            •	FoodName
            •	FoodPrice
            •	AvailableQuantity
        */


        //field 

        /// <summary>
        /// Static field s_foodID used to autoincrement FoodID of the instance of <see cref="FoodDetails"/>
        /// </summary>
        private static int s_foodID = 100;


        //Auto property

        /// <summary>
        /// FoodID Property used to hold a Food's ID of the instance of <see cref="FoodDetails"/>
        /// </summary>
        public string FoodID { get; }//read only property

        /// <summary>
        /// FoodName Property used to hold a Food Name of the instance of <see cref="FoodDetails"/>
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// FoodPrice Property used to hold a Food Price of the instance of <see cref="FoodDetails"/>
        /// </summary>
        public double FoodPrice { get; set; }

        /// <summary>
        /// AvailableQuantity Property used to hold a Food Available Quantity of the instance of <see cref="FoodDetails"/>
        /// </summary>
        public int AvailableQuantity { get; set; }

        //Constructor

        /// <summary>
        /// Constructor FoodDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="foodName">foodName parameter used to assign value to its associated property</param>
        /// <param name="foodPrice">foodPrice parameter used to assign value to its associated property</param>
        /// <param name="availableQuantity">availableQuantity parameter used to assign value to its associated property</param>
        public FoodDetails(string foodName, double foodPrice, int availableQuantity)
        {
            s_foodID++;
            FoodID = "FID" + s_foodID;

            FoodName = foodName;
            FoodPrice = foodPrice;
            AvailableQuantity = availableQuantity;
        }

    }
}