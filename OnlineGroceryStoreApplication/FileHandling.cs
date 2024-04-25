using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreApplication
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("OnlineGroceryStoreApplication"))
            {
                Directory.CreateDirectory("OnlineGroceryStoreApplication");
            }

            if (!File.Exists("OnlineGroceryStoreApplication/CustomerDetails.csv"))
            {
                File.Create("OnlineGroceryStoreApplication/CustomerDetails.csv").Close();
            }

            if (!File.Exists("OnlineGroceryStoreApplication/BookingDetails.csv"))
            {
                File.Create("OnlineGroceryStoreApplication/BookingDetails.csv").Close();
            }

            if (!File.Exists("OnlineGroceryStoreApplication/OrderDetails.csv"))
            {
                File.Create("OnlineGroceryStoreApplication/OrderDetails.csv").Close();
            }

            if (!File.Exists("OnlineGroceryStoreApplication/ProductDetails.csv"))
            {
                File.Create("OnlineGroceryStoreApplication/ProductDetails.csv").Close();
            }
        }


        public static void ReadFromCSV()
        {

            //customer details
            string[] users = File.ReadAllLines("OnlineGroceryStoreApplication/CustomerDetails.csv");
            foreach (string user in users)
            {
                CustomerDetails customer = new CustomerDetails(user);
                Operations.customerDetailsList.Add(customer);
            }

            //product details
            string[] products = File.ReadAllLines("OnlineGroceryStoreApplication/ProductDetails.csv");
            foreach (string product in products)
            {
                ProductDetails productDetails = new ProductDetails(product);
                Operations.productDetailsList.Add(productDetails);
            }

            //order details
            string[] orders = File.ReadAllLines("OnlineGroceryStoreApplication/OrderDetails.csv");
            foreach (string order in orders)
            {
                OrderDetails orderDetails = new OrderDetails(order);
                Operations.orderDetailsList.Add(orderDetails);
            }

            //booking details
            string[] bookings = File.ReadAllLines("OnlineGroceryStoreApplication/bookingDetails.csv");
            foreach (string booking in bookings)
            {
                BookingDetails bookingDetails = new BookingDetails(booking);
                Operations.bookingDetailsList.Add(bookingDetails);
            }

        }
        public static void WriteToCSV()
        {
            //customer details
            string[] customers = new string[Operations.customerDetailsList.Count];
            for (int i = 0; i < Operations.customerDetailsList.Count; i++)
            {
                customers[i] = $"{Operations.customerDetailsList[i].CustomerID},{Operations.customerDetailsList[i].WalletBalance},{Operations.customerDetailsList[i].Name},{Operations.customerDetailsList[i].FatherName},{Operations.customerDetailsList[i].Gender},{Operations.customerDetailsList[i].Mobile},{Operations.customerDetailsList[i].DOB:dd/MM/yyyy},{Operations.customerDetailsList[i].MailID}";
            }

            File.WriteAllLines("OnlineGroceryStoreApplication/CustomerDetails.csv", customers);

            //food details
            string[] products = new string[Operations.productDetailsList.Count];
            for (int i = 0; i < Operations.productDetailsList.Count; i++)
            {
                products[i] = $"{Operations.productDetailsList[i].ProductID},{Operations.productDetailsList[i].ProductName},{Operations.productDetailsList[i].PricePerQuantity},{Operations.productDetailsList[i].QuantityAvailable}";
            }

            File.WriteAllLines("OnlineGroceryStoreApplication/ProductDetails.csv", products);

            //booking details
            string[] orders = new string[Operations.orderDetailsList.Count];
            for (int i = 0; i < Operations.orderDetailsList.Count; i++)
            {
                orders[i] = $"{Operations.orderDetailsList[i].OrderID},{Operations.orderDetailsList[i].BookingID},{Operations.orderDetailsList[i].ProductID},{Operations.orderDetailsList[i].PurchaseCount},{Operations.orderDetailsList[i].PriceOfOrder}";
            }

            File.WriteAllLines("OnlineGroceryStoreApplication/OrderDetails.csv", orders);

            //orderdetails class
            string[] bookings = new string[Operations.bookingDetailsList.Count];
            for (int i = 0; i < Operations.bookingDetailsList.Count; i++)
            {
                bookings[i] = $"{Operations.bookingDetailsList[i].BookingID},{Operations.bookingDetailsList[i].CustomerID},{Operations.bookingDetailsList[i].TotalPrice},{Operations.bookingDetailsList[i].DateOfBooking:dd/MM/yyyy},{Operations.bookingDetailsList[i].BookingStatus}";
            }
            File.WriteAllLines("OnlineGroceryStoreApplication/BookingDetails.csv", bookings);


        }
    }
}