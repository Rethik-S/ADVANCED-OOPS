using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreApplication
{
    public class ProductDetails
    {
        //field
        /// <summary>
        /// s_productID field used to increment a ProductID of the instance of <see cref="ProductDetails"/>
        /// </summary>
        private static int s_productID = 2000;



        //Auto property
        /// <summary>
        /// ProductID Property used to hold a  Product ID of the instance of <see cref="ProductDetails"/>
        /// </summary>
        public string ProductID { get; }
        /// <summary>
        /// ProductName Property used to hold a  Product ProductName of the instance of <see cref="ProductDetails"/>
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// QuantityAvailable Property used to hold a  Product Quantity Available of the instance of <see cref="ProductDetails"/>
        /// </summary>
        public int QuantityAvailable { get; set; }
        /// <summary>
        /// PricePerQuantity Property used to hold a  Product Price Per Quantity of the instance of <see cref="ProductDetails"/>
        /// </summary>
        public double PricePerQuantity { get; set; }


        /// <summary>
        /// Constructor ProductDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="productName">productName used to store data in the associated property</param>
        /// <param name="quantityAvailable">quantityAvailable used to store data in the associated property</param>
        /// <param name="pricePerQuantity">pricePerQuantity used to store data in the associated property</param>
        public ProductDetails(string productName, int quantityAvailable, double pricePerQuantity)
        {
            s_productID++;
            ProductID = "PID" + s_productID;

            ProductName = productName;
            QuantityAvailable = quantityAvailable;
            PricePerQuantity = pricePerQuantity;
        }
        public ProductDetails(string product)
        {
            string[] values = product.Split(",");
            s_productID = int.Parse(values[0].Remove(0, 3));
            ProductID = values[0];
            ProductName = values[1];
            QuantityAvailable = int.Parse(values[2]);
            PricePerQuantity = double.Parse(values[3]);
        }


    }
}