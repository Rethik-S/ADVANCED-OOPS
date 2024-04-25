using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public static class FileHandling
    {
        public static void Create()
        {
            //folder
            if (!Directory.Exists("CafeteriaCardManagement"))
            {
                Console.WriteLine($"Creating Folder");

                Directory.CreateDirectory("CafeteriaCardManagement");
            }

            //file

            //User details
            if (!File.Exists("CafeteriaCardManagement/UserDetails.csv"))
            {
                Console.WriteLine($"Creating File");

                File.Create("CafeteriaCardManagement/UserDetails.csv").Close();
            }

            //Food details
            if (!File.Exists("CafeteriaCardManagement/FoodDetails.csv"))
            {
                Console.WriteLine($"Creating File");

                File.Create("CafeteriaCardManagement/FoodDetails.csv").Close();
            }

            //order details
            if (!File.Exists("CafeteriaCardManagement/OrderDetails.csv"))
            {
                Console.WriteLine($"Creating File");

                File.Create("CafeteriaCardManagement/OrderDetails.csv").Close();
            }
            //Cart Items
            if (!File.Exists("CafeteriaCardManagement/CartItems.csv"))
            {
                Console.WriteLine($"Creating File");

                File.Create("CafeteriaCardManagement/CartItems.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            //UserDetails
            string[] users = new string[Operations.userDetailsList.Count];
            int index = 0;
            //public UserDetails(string name, string fatherName, Gender gender, string mobile, string mailID, string workStationNumber) : base(name, fatherName, gender, mobile, mailID)

            foreach (UserDetails user in Operations.userDetailsList)
            {
                users[index++] = $"{user.UserID},{user.Name},{user.FatherName},{user.Gender},{user.Mobile},{user.MailID},{user.WorkStationNumber}";
            }

            File.WriteAllLines("CafeteriaCardManagement/UserDetails.csv",users);
        }

        public static void ReadFromCSV()
        {
            string[] students = File.ReadAllLines("CafeteriaCardManagement/UserDetails.csv");

            foreach(string student in students)
            {
                UserDetails user = new UserDetails(student);
                Operations.userDetailsList.Add(user);

            }
        }


    }
}