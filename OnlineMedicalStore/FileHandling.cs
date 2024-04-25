using System;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace OnlineMedicalStore
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("OnlineMedicalStore"))
            {
                Directory.CreateDirectory("OnlineMedicalStore");
            }

            if (!File.Exists("OnlineMedicalStore/UserDetails.csv"))
            {
                File.Create("OnlineMedicalStore/UserDetails.csv").Close();
            }

            if (!File.Exists("OnlineMedicalStore/MedicineDetails.csv"))
            {
                File.Create("OnlineMedicalStore/MedicineDetails.csv").Close();
            }


            if (!File.Exists("OnlineMedicalStore/OrderDetails.csv"))
            {
                File.Create("OnlineMedicalStore/OrderDetails.csv").Close();
            }
        }

        public static void ReadFromCSV()
        {
            //user details
            string[] users = File.ReadAllLines("OnlineMedicalStore/UserDetails.csv");
            foreach(string user in users)
            {
                UserDetails userDetails = new UserDetails(user);
                Operations.userDetailsList.Add(userDetails);
            }

            //medicine details
            string[] medicines = File.ReadAllLines("OnlineMedicalStore/MedicineDetails.csv");
            foreach(string medicine in medicines)
            {
                MedicineDetails medicineDetails = new MedicineDetails(medicine);
                Operations.medicineDetailsList.Add(medicineDetails);
            }

            //order details
            string[] orders = File.ReadAllLines("OnlineMedicalStore/OrderDetails.csv");
            foreach(string order in orders)
            {
                OrderDetails orderDetails = new OrderDetails(order);
                Operations.orderDetailsList.Add(orderDetails);
            }
        }

        public static void WriteToCSV()
        {
            //user details
            string[] users = new string[Operations.userDetailsList.Count];
            for (int i = 0; i < Operations.userDetailsList.Count; i++)
            {
                users[i] = $"{Operations.userDetailsList[i].UserID},{Operations.userDetailsList[i].Name},{Operations.userDetailsList[i].Age},{Operations.userDetailsList[i].City},{Operations.userDetailsList[i].PhoneNumber},{Operations.userDetailsList[i].WalletBalance}";
            }
            File.WriteAllLines("OnlineMedicalStore/UserDetails.csv", users);

            //medicine details
            string[] medicines = new string[Operations.medicineDetailsList.Count];
            for (int i = 0; i < Operations.medicineDetailsList.Count; i++)
            {
                medicines[i] = $"{Operations.medicineDetailsList[i].MedicineID},{Operations.medicineDetailsList[i].MedicineName},{Operations.medicineDetailsList[i].AvailableCount},{Operations.medicineDetailsList[i].Price},{Operations.medicineDetailsList[i].DateOfExpiry:dd/MM/yyyy}";
            }
            File.WriteAllLines("OnlineMedicalStore/MedicineDetails.csv", medicines);

            //order details
            string[] orders = new string[Operations.orderDetailsList.Count];
            for (int i = 0; i < Operations.orderDetailsList.Count; i++)
            {
                orders[i] = $"{Operations.orderDetailsList[i].OrderID},{Operations.orderDetailsList[i].UserID},{Operations.orderDetailsList[i].MedicineID},{Operations.orderDetailsList[i].MedicineCount},{Operations.orderDetailsList[i].TotalPrice},{Operations.orderDetailsList[i].OrderDate:dd/MM/yyyy},{Operations.orderDetailsList[i].OrderStatus}";
            }
            File.WriteAllLines("OnlineMedicalStore/OrderDetails.csv", orders);

        }
    }
}