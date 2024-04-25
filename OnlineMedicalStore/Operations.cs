using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class Operations
    {
        //local/global cuurent user
        static UserDetails currentLoggedInUser;

        //static list creation

        public static CustomList<UserDetails> userDetailsList = new CustomList<UserDetails>();
        public static CustomList<MedicineDetails> medicineDetailsList = new CustomList<MedicineDetails>();
        public static CustomList<OrderDetails> orderDetailsList = new CustomList<OrderDetails>();


        //Main menu
        public static void MainMenu()
        {
            string mainChoice = "yes";
            do
            {
                Console.WriteLine($"Main Menu");
                Console.WriteLine();
                Console.WriteLine($"1. User Registration\n2. User Login\n3. Exit");
                Console.Write($"Select a option: ");
                string mainOption = Console.ReadLine();
                switch (mainOption)
                {
                    case "1":
                        {
                            UserRegistration();
                            break;
                        }
                    case "2":
                        {
                            UserLogin();
                            break;
                        }
                    case "3":
                        {
                            mainChoice = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Enter a valid option.");
                            break;
                        }
                }


            } while (mainChoice == "yes");
        }//Main menu ends


        public static void UserRegistration()
        {
            //get user details
            Console.Write($"Enter user name: ");
            string userName = Console.ReadLine();

            Console.Write($"Enter age: ");
            string age = Console.ReadLine();

            Console.Write($"Enter City: ");
            string city = Console.ReadLine();

            Console.Write($"Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write($"Enter balance to deposit: ");
            double amount = double.Parse(Console.ReadLine());

            //create user object
            UserDetails user = new UserDetails(userName, age, city, phone, amount);

            //add to list
            userDetailsList.Add(user);

            //diplay user id
            Console.WriteLine($"Registration successfull.Your ID is {user.UserID}");

        }

        public static void UserLogin()
        {
            Console.Write("Enter user ID: ");
            string userID = Console.ReadLine();
            bool flag = true;
            foreach (UserDetails user in userDetailsList)
            {
                if (user.UserID.Equals(userID))
                {
                    flag = false;
                    currentLoggedInUser = user;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine($"Invalid User ID");

            }

        }

        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {

                Console.WriteLine($"1. Show medicine list\n2. Purchase medicine\n3. Modify purchase\n4. Cancel purchase\n5. Show purchase history\n6. Recharge Wallet\n7. Show Wallet Balance\n8. Exit");
                Console.Write("Select a option: ");
                string subOption = Console.ReadLine();
                switch (subOption)
                {
                    case "1":
                        {
                            ShowMedicineList();
                            break;
                        }
                    case "2":
                        {
                            PurchaseMedicine();
                            break;
                        }
                    case "3":
                        {
                            ModifyPurchase();
                            break;
                        }
                    case "4":
                        {
                            CancelPurchase();
                            break;
                        }
                    case "5":
                        {
                            ShowPurchaseHistory();
                            break;
                        }
                    case "6":
                        {
                            RechargeWallet();
                            break;
                        }
                    case "7":
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case "8":
                        {
                            subChoice = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Enter a valid option.");

                            break;
                        }
                }
            } while (subChoice == "yes");

        }


        public static void ShowMedicineList()
        {
            foreach (MedicineDetails medicine in medicineDetailsList)
            {
                Console.WriteLine($"{medicine.MedicineID}|{medicine.MedicineName}|{medicine.AvailableCount}|{medicine.Price}|{medicine.DateOfExpiry:dd/MM/yyyy}");
            }
        }
        public static void PurchaseMedicine()
        {
            ShowMedicineList();
            Console.Write($"Enter medicine ID: ");
            string medicineID = Console.ReadLine();
            Console.Write($"Enter medicine count: ");
            int medicineCount = int.Parse(Console.ReadLine());
            bool flag = true;
            foreach (MedicineDetails medicine in medicineDetailsList)
            {
                if (medicine.MedicineID.Equals(medicineID))
                {
                    flag = false;
                    if (medicineCount > medicine.AvailableCount)
                    {
                        Console.WriteLine($"medicine quantity not available.");
                        return;
                    }
                    else
                    {
                        TimeSpan span = DateTime.Now - medicine.DateOfExpiry;
                        if (span.Days > 0)
                        {
                            Console.WriteLine($"Medicine is not available");
                            return;
                        }
                        else
                        {
                            double totalPrice = medicine.Price * medicineCount;
                            if (currentLoggedInUser.WalletBalance < totalPrice)
                            {
                                Console.WriteLine($"Insufficient balance. please recharge");
                                return;
                            }
                            else
                            {
                                medicine.AvailableCount -= medicineCount;
                                currentLoggedInUser.DeductBalance(totalPrice);
                                OrderDetails orderDetails = new OrderDetails(currentLoggedInUser.UserID, medicine.MedicineID, medicineCount, totalPrice, DateTime.Now, OrderStatus.Purchased);
                                orderDetailsList.Add(orderDetails);
                                return;
                            }
                        }
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine($"Invalid medicine ID");

            }


        }
        public static void ModifyPurchase()
        {
            bool flag = true;
            foreach (OrderDetails orders in orderDetailsList)
            {
                if (orders.UserID.Equals(currentLoggedInUser.UserID))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine($"no Purchase to modify");

            }
            else
            {
                foreach (OrderDetails order in orderDetailsList)
                {
                    if (order.UserID.Equals(currentLoggedInUser.UserID))
                    {
                        Console.WriteLine($"{order.OrderID}|{order.UserID}|{order.MedicineID}|{order.MedicineCount}|{order.TotalPrice}|{order.OrderDate:dd/MM/yyyy}|{order.OrderStatus}|");

                    }
                }
                Console.Write($"Enter order ID: ");
                string orderID = Console.ReadLine();
                bool flag2 = true;
                foreach (OrderDetails orderDetails in orderDetailsList)
                {
                    if (orderDetails.OrderID.Equals(orderID) && orderDetails.UserID.Equals(currentLoggedInUser.UserID))
                    {
                        flag2 = false;
                        Console.Write($"Enter the quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        foreach (MedicineDetails medicine in medicineDetailsList)
                        {
                            if (medicine.MedicineID.Equals(orderDetails.MedicineID))
                            {
                                if (quantity <= medicine.AvailableCount)
                                {
                                    double totalPrice = medicine.Price * quantity;
                                    medicine.AvailableCount += orderDetails.MedicineCount;
                                    medicine.AvailableCount -= quantity;
                                    orderDetails.MedicineCount = quantity;
                                    orderDetails.TotalPrice = totalPrice;
                                }
                                else
                                {
                                    Console.WriteLine($"Quantity not available.");

                                }
                            }

                        }
                        break;
                    }
                }
                if (flag2)
                {
                    Console.WriteLine($"Invalid order ID");
                }

            }
        }
        public static void CancelPurchase()
        {
            foreach (OrderDetails orderDetails in orderDetailsList)
            {
                if (orderDetails.UserID.Equals(currentLoggedInUser.UserID) && orderDetails.OrderStatus == OrderStatus.Purchased)
                {
                    Console.WriteLine($"{orderDetails.OrderID}|{orderDetails.UserID}|{orderDetails.MedicineID}|{orderDetails.MedicineCount}|{orderDetails.TotalPrice}|{orderDetails.OrderDate:dd/MM/yyyy}|{orderDetails.OrderStatus}|");

                }
            }
            Console.Write($"Enter order ID: ");
            string orderID = Console.ReadLine();
            bool flag = true;
            foreach (OrderDetails order in orderDetailsList)
            {
                if (order.UserID.Equals(currentLoggedInUser.UserID) && order.OrderID.Equals(orderID))
                {
                    flag = false;
                    foreach (MedicineDetails medicine in medicineDetailsList)
                    {
                        if (order.MedicineID.Equals(medicine.MedicineID))
                        {
                            medicine.AvailableCount += order.MedicineCount;
                            currentLoggedInUser.WalletRecharge(order.TotalPrice);
                            order.OrderStatus = OrderStatus.Cancelled;
                            Console.WriteLine($"Order cancelled");

                            break;
                        }
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine($"Invalid order ID");

            }
        }
        public static void ShowPurchaseHistory()
        {
            bool flag = true;
            foreach (OrderDetails orders in orderDetailsList)
            {
                if (orders.UserID.Equals(currentLoggedInUser.UserID))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine($"no Purchase history");

            }
            else
            {
                foreach (OrderDetails order in orderDetailsList)
                {
                    if (order.UserID.Equals(currentLoggedInUser.UserID))
                    {

                        Console.WriteLine($"{order.OrderID}|{order.UserID}|{order.MedicineID}|{order.MedicineCount}|{order.TotalPrice}|{order.OrderDate:dd/MM/yyyy}|{order.OrderStatus}|");

                    }
                }
            }
        }
        public static void RechargeWallet()
        {
            Console.Write("Do you want to recharge: ");
            string rechargeChoice = Console.ReadLine();
            if (rechargeChoice == "yes")
            {
                Console.Write($"Enter amount to recharge: ");
                double amount = double.Parse(Console.ReadLine());
                while (!(amount > 0))
                {
                    Console.WriteLine($"Enter a valid number");
                    Console.Write($"Enter amount to recharge: ");
                    amount = double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"{amount} Recharge successful.\nYour balance {currentLoggedInUser.WalletRecharge(amount)}");
            }


        }
        public static void ShowWalletBalance()
        {
            Console.WriteLine($"Your balance {currentLoggedInUser.WalletBalance}");

        }



        //default data
        public static void DefaultData()
        {
            UserDetails user1 = new UserDetails("Ravi", "33", "Theni", "9877774440", 400);
            UserDetails user2 = new UserDetails("Baskaran", "33", "Chennai", "8847757470", 500);

            userDetailsList.Add(user1);
            userDetailsList.Add(user2);

            MedicineDetails medicine1 = new MedicineDetails("Paracitamol", 40, 5, new DateTime(2024, 6, 30));
            MedicineDetails medicine2 = new MedicineDetails("Calpol", 10, 5, new DateTime(2024, 5, 30));
            MedicineDetails medicine3 = new MedicineDetails("Gelucil", 3, 40, new DateTime(2024, 4, 30));
            MedicineDetails medicine4 = new MedicineDetails("Metrogel", 5, 50, new DateTime(2024, 12, 30));
            MedicineDetails medicine5 = new MedicineDetails("Povidin Iodin", 10, 50, new DateTime(2024, 10, 30));

            medicineDetailsList.AddRange(new CustomList<MedicineDetails> { medicine1, medicine2, medicine3, medicine4, medicine5 });

            OrderDetails order1 = new OrderDetails("UID1001", "MD101", 3, 15, new DateTime(2022, 11, 13), OrderStatus.Purchased);
            OrderDetails order2 = new OrderDetails("UID1001", "MD102", 2, 10, new DateTime(2022, 11, 13), OrderStatus.Cancelled);
            OrderDetails order3 = new OrderDetails("UID1001", "MD104", 2, 100, new DateTime(2022, 11, 13), OrderStatus.Purchased);
            OrderDetails order4 = new OrderDetails("UID1002", "MD103", 3, 120, new DateTime(2022, 11, 15), OrderStatus.Cancelled);
            OrderDetails order5 = new OrderDetails("UID1002", "MD105", 5, 250, new DateTime(2022, 11, 15), OrderStatus.Purchased);
            OrderDetails order6 = new OrderDetails("UID1002", "MD102", 3, 15, new DateTime(2022, 11, 15), OrderStatus.Purchased);

            orderDetailsList.AddRange(new CustomList<OrderDetails> { order1, order2, order3, order4, order5, order6 });
        }//default data ends
    }
}