using System;
using System.IO;

namespace QwickFoodz
{
    public static class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("QwickFoodZ"))
            {
                Console.WriteLine($"Creating QwickFoodZ folder");
                Directory.CreateDirectory("QwickFoodZ");
            }

            if (!File.Exists("QwickFoodZ/CustomerDetails.csv"))
            {
                Console.WriteLine($"Creating Customer details file");
                File.Create("QwickFoodZ/CustomerDetails.csv").Close();
            }
            if (!File.Exists("QwickFoodZ/FoodDetails.csv"))
            {
                Console.WriteLine($"Creating Food Details file");
                File.Create("QwickFoodZ/FoodDetails.csv").Close();
            }
            if (!File.Exists("QwickFoodZ/ItemDetails.csv"))
            {
                Console.WriteLine($"Creating item details file");
                File.Create("QwickFoodZ/ItemDetails.csv").Close();
            }
            if (!File.Exists("QwickFoodZ/OrderDetails.csv"))
            {
                Console.WriteLine($"creating order details file");
                File.Create("QwickFoodZ/OrderDetails.csv").Close();
            }
        }

        public static void ReadFromCSV()
        {

            //customer details
            string[] users = File.ReadAllLines("QwickFoodZ/CustomerDetails.csv");
            foreach (string user in users)
            {
                CustomerDetails customer = new CustomerDetails(user);
                Operations.customerDetailsList.Add(customer);
            }

            //food details
            string[] foods = File.ReadAllLines("QwickFoodZ/FoodDetails.csv");
            foreach (string food in foods)
            {
                FoodDetails foodDetails = new FoodDetails(food);
                Operations.foodDetailsList.Add(foodDetails);
            }

            //item details
            string[] items = File.ReadAllLines("QwickFoodZ/ItemDetails.csv");
            foreach (string item in items)
            {
                ItemDetails itemDetails = new ItemDetails(item);
                Operations.itemDetailsList.Add(itemDetails);
            }

            //order details
            string[] orders = File.ReadAllLines("QwickFoodZ/OrderDetails.csv");
            foreach (string order in orders)
            {
                OrderDetails orderDetails = new OrderDetails(order);
                Operations.orderDetailsList.Add(orderDetails);
            }

        }

        public static void WriteTOCSV()
        {
            //customer details
            string[] customers = new string[Operations.customerDetailsList.Count];
            for (int i = 0; i < Operations.customerDetailsList.Count; i++)
            {
                customers[i] = $"{Operations.customerDetailsList[i].CustomerID},{Operations.customerDetailsList[i].WalletBalance},{Operations.customerDetailsList[i].Name},{Operations.customerDetailsList[i].FatherName},{Operations.customerDetailsList[i].Gender},{Operations.customerDetailsList[i].Mobile},{Operations.customerDetailsList[i].DOB:dd/MM/yyyy},{Operations.customerDetailsList[i].MailID},{Operations.customerDetailsList[i].Location}";
            }

            File.WriteAllLines("QwickFoodZ/CustomerDetails.csv", customers);

            //food details
            string[] foods = new string[Operations.foodDetailsList.Count];
            for (int i = 0; i < Operations.foodDetailsList.Count; i++)
            {
                foods[i] = $"{Operations.foodDetailsList[i].FoodID},{Operations.foodDetailsList[i].FoodName},{Operations.foodDetailsList[i].PricePerQuantity},{Operations.foodDetailsList[i].QuantityAvailable}";
            }

            File.WriteAllLines("QwickFoodZ/FoodDetails.csv", foods);

            //item details
            string[] items = new string[Operations.itemDetailsList.Count];
            for (int i = 0; i < Operations.itemDetailsList.Count; i++)
            {
                items[i] = $"{Operations.itemDetailsList[i].ItemID},{Operations.itemDetailsList[i].OrderID},{Operations.itemDetailsList[i].FoodID},{Operations.itemDetailsList[i].PurchaseCount},{Operations.itemDetailsList[i].PriceOfOrder}";
            }

            File.WriteAllLines("QwickFoodZ/ItemDetails.csv", items);

            //orderdetails class
            string[] orders = new string[Operations.orderDetailsList.Count];
            for (int i = 0; i < Operations.orderDetailsList.Count; i++)
            {
                orders[i] = $"{Operations.orderDetailsList[i].OrderID},{Operations.orderDetailsList[i].CustomerID},{Operations.orderDetailsList[i].TotalPrice},{Operations.orderDetailsList[i].DateOfOrder:dd/MM/yyyy},{Operations.orderDetailsList[i].OrderStatus}";
            }
            File.WriteAllLines("QwickFoodZ/OrderDetails.csv", orders);

        }
    }
}