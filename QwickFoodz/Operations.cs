using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class Operations
    {
        //local/global static customer details
        static CustomerDetails currentLoggedInCustomer;

        //static class creation
        public static CustomList<CustomerDetails> customerDetailsList = new CustomList<CustomerDetails>();
        public static CustomList<FoodDetails> foodDetailsList = new CustomList<FoodDetails>();
        public static CustomList<OrderDetails> orderDetailsList = new CustomList<OrderDetails>();
        public static CustomList<ItemDetails> itemDetailsList = new CustomList<ItemDetails>();


        //Main Menu 
        public static void MainMenu()
        {
            Console.WriteLine($"Main menu");

            string mainChoice = "yes";
            do
            {
                Console.WriteLine($"1. Customer Registration\n2. Customer Login\n3. Exit");
                //ask user to select a option
                Console.Write($"Select a option: ");
                string mainOption = Console.ReadLine();
                switch (mainOption)
                {
                    case "1":
                        {
                            Console.WriteLine($"*** Customer Registration***");
                            CustomerRegistration();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine($"*** Customer Login***");
                            CustomerLogin();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine($"Application exited succesfully.");
                            mainChoice = "no";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (mainChoice == "yes");



        }//main menu ends

        //customer registration
        public static void CustomerRegistration()
        {
            //getting customer details
            Console.Write($"Enter the name: ");
            string name = Console.ReadLine();

            Console.Write($"Enter father name: ");
            string fatherName = Console.ReadLine();

            System.Console.Write("Enter gender ( Male or Female or Transgender ): ");
            Gender gender;
            bool isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
            while (!isGen)
            {
                Console.WriteLine("Provide valid gender");
                Console.Write("Enter gender ( Male or Female or Transgender ): ");
                isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
            }

            Console.Write($"Enter mobile number: ");
            string mobile = Console.ReadLine();

            Console.Write("Enter your Date of birth: ");
            DateTime dob;
            bool isDOBValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            while (!isDOBValid)
            {
                Console.Write("Enter your Date of birth: ");
                isDOBValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            }

            Console.Write($"Enter Mail ID: ");
            string mailID = Console.ReadLine();

            Console.Write($"Enter location: ");
            string location = Console.ReadLine();

            double walletBalance;
            Console.Write("Enter amount to deposit in wallet: ");
            bool iswalletBalanceValid = double.TryParse(Console.ReadLine(), null, out walletBalance);
            while (!iswalletBalanceValid || !(walletBalance > 0))
            {
                Console.WriteLine("Enter valid Number");
                Console.Write("Enter amount to deposit in wallet: ");
                iswalletBalanceValid = double.TryParse(Console.ReadLine(), null, out walletBalance);

            }

            //create new customer details object
            CustomerDetails customer = new CustomerDetails(walletBalance, name, fatherName, gender, mobile, dob, mailID, location);
            //Add object to list
            customerDetailsList.Add(customer);

            Console.WriteLine($"Registration successfull. your customer ID is {customer.CustomerID}");

        }//customer registration ends

        //customer login
        public static void CustomerLogin()
        {
            //get customer ID
            Console.Write($"Enter customer ID: ");
            string customerID = Console.ReadLine().ToUpper();
            bool flag = true;
            //check user ID is valid
            foreach (CustomerDetails customer in customerDetailsList)
            {
                if (customer.CustomerID.Equals(customerID))
                {
                    flag = false;
                    //assign customer object to global variable 
                    currentLoggedInCustomer = customer;
                    //redirect to submenu
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                //dislpay invalid id
                Console.WriteLine($"Invalid customer ID");
            }
        }//customer login ends

        //sub menu
        public static void SubMenu()
        {
            Console.WriteLine($"Sub menu");

            string subChoice = "yes";
            do
            {
                Console.WriteLine($"1. Show Customer Details\n2. Order product\n3. Cancel Order\n4. Modify Order\n5. Order History\n6. Recharge Wallet\n7. Show Wallet Balance\n8. Exit");
                //get option from user
                Console.Write($"select a option: ");
                string subOption = Console.ReadLine();
                switch (subOption)
                {
                    case "1":
                        {
                            ShowProfile();
                            break;
                        }
                    case "2":
                        {
                            OrderFood();
                            break;
                        }
                    case "3":
                        {
                            CancelOrder();
                            break;
                        }
                    case "4":
                        {
                            ModifyOrder();
                            break;
                        }
                    case "5":
                        {
                            OrderHistory();
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
        }//sub menu ends

        //ShowProfile
        public static void ShowProfile()
        {
            //display profile information
            Console.WriteLine($"{currentLoggedInCustomer.CustomerID}|{currentLoggedInCustomer.WalletBalance}|{currentLoggedInCustomer.Name}|{currentLoggedInCustomer.FatherName}|{currentLoggedInCustomer.Gender}|{currentLoggedInCustomer.Mobile}|{currentLoggedInCustomer.DOB:dd/MM/yyyy}|{currentLoggedInCustomer.MailID}|{currentLoggedInCustomer.Location}");
        }//ShowProfile ends

        //Order Food
        public static void OrderFood()
        {
            string choice = "yes";
            //create order details to initiate order
            OrderDetails order = new OrderDetails(currentLoggedInCustomer.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);
            //create local item list
            CustomList<ItemDetails> localItemsList = new CustomList<ItemDetails>();
            double totalOrderPrice = 0;
            do
            {
                //display food details
                foreach (FoodDetails foodDetails in foodDetailsList)
                {
                    Console.WriteLine($"|{foodDetails.FoodID}|{foodDetails.FoodName}|{foodDetails.PricePerQuantity}|{foodDetails.QuantityAvailable}|");

                }
                //get food id
                Console.Write($"Enter Food ID: ");
                string foodID = Console.ReadLine().ToUpper();
                //get quantity
                int quantity;
                Console.Write("Enter quantity: ");
                bool isquantityValid = int.TryParse(Console.ReadLine(), null, out quantity);
                while (!isquantityValid || !(quantity > 0))
                {
                    Console.WriteLine("Enter valid Number");
                    Console.Write("Enter quantity: ");
                    isquantityValid = int.TryParse(Console.ReadLine(), null, out quantity);

                }
                bool flag = true;
                foreach (FoodDetails food in foodDetailsList)
                {
                    //validate food id
                    if (food.FoodID.Equals(foodID))
                    {
                        flag = false;
                        //validate quantity is available
                        if (quantity > food.QuantityAvailable)
                        {
                            //display quantity unavailable
                            Console.WriteLine($"Food Quantity unavailable. we have {food.QuantityAvailable} {food.FoodName}");
                        }
                        else
                        {
                            //calculate item price
                            double totalItemPrice = quantity * food.PricePerQuantity;
                            //create item object
                            ItemDetails item = new ItemDetails(order.OrderID, food.FoodID, quantity, totalItemPrice);
                            //reduce available count in food details
                            food.QuantityAvailable -= quantity;
                            //add item to local items list
                            localItemsList.Add(item);
                            //add item price to total bill
                            totalOrderPrice += totalItemPrice;
                        }
                        break;
                    }
                }
                if (flag)
                {
                    //diplay invalid food if
                    Console.WriteLine($"Invalid food ID.");

                }
                //ask user to order again
                Console.Write($"Do you want to order again : ");
                choice = Console.ReadLine().ToLower();

            } while (choice == "yes");

            //check if user added items
            if (localItemsList.Count > 0)
            {
                //ask user to confirm the purchase
                Console.Write($"Do you want to confirm purchase : ");
                string confirmation = Console.ReadLine().ToLower();
                switch (confirmation)
                {
                    case "yes":
                        {
                            //check wallet balance
                            if (totalOrderPrice > currentLoggedInCustomer.WalletBalance)
                            {
                                string rechargeChoice = "yes";
                                //recharge until user demands
                                while (rechargeChoice == "yes")
                                {
                                    Console.WriteLine($"Insufficient balance.");
                                    RechargeWallet();
                                    if (totalOrderPrice <= currentLoggedInCustomer.WalletBalance)
                                    {
                                        break;
                                    }
                                }
                                //check wallet balance
                                if (totalOrderPrice > currentLoggedInCustomer.WalletBalance)
                                {
                                    //diplay user Insufficient balance
                                    Console.WriteLine($"Insufficient balance. Order is not placed.");
                                    //return items to food details
                                    foreach (ItemDetails item in localItemsList)
                                    {
                                        foreach (FoodDetails foodDetails in foodDetailsList)
                                        {
                                            if (item.FoodID.Equals(foodDetails.FoodID))
                                            {
                                                foodDetails.QuantityAvailable += item.PurchaseCount;
                                            }
                                        }
                                    }
                                    return;
                                }
                                else
                                {
                                    //update order price
                                    order.TotalPrice = totalOrderPrice;
                                    // update order status
                                    order.OrderStatus = OrderStatus.Ordered;
                                    //deduct amount from user
                                    currentLoggedInCustomer.DeductBalance(totalOrderPrice);
                                    //add local items list to global
                                    itemDetailsList.AddRange(localItemsList);
                                    //add order to order details
                                    orderDetailsList.Add(order);
                                    //display user order is placed
                                    Console.WriteLine($"Order is placed. order ID {order.OrderID}");
                                    return;
                                }

                            }
                            else
                            {
                                //update order price
                                order.TotalPrice = totalOrderPrice;
                                // update order status
                                order.OrderStatus = OrderStatus.Ordered;
                                //deduct amount from user
                                currentLoggedInCustomer.DeductBalance(totalOrderPrice);
                                //add local items list to global
                                itemDetailsList.AddRange(localItemsList);
                                //add order to order details
                                orderDetailsList.Add(order);
                                //display user order is placed
                                Console.WriteLine($"Order is placed. order ID {order.OrderID}");
                                return;
                            }
                        }
                    case "no":
                        {
                            //diplay user order not placed
                            Console.WriteLine($"Order is not placed.");
                            //return items to food details
                            foreach (ItemDetails item in localItemsList)
                            {
                                foreach (FoodDetails foodDetails in foodDetailsList)
                                {
                                    if (item.FoodID.Equals(foodDetails.FoodID))
                                    {
                                        foodDetails.QuantityAvailable += item.PurchaseCount;
                                    }
                                }
                            }
                            return;
                        }
                    default:
                        {
                            Console.WriteLine($"Invalid confirmation. Order is not placed.");
                            //return items to food details
                            foreach (ItemDetails item in localItemsList)
                            {
                                foreach (FoodDetails foodDetails in foodDetailsList)
                                {
                                    if (item.FoodID.Equals(foodDetails.FoodID))
                                    {
                                        foodDetails.QuantityAvailable += item.PurchaseCount;
                                    }
                                }
                            }
                            break;
                        }
                }

            }

        }//Order Food ends

        //Cancel order
        public static void CancelOrder()
        {
            bool flag = true;
            //check if user has orders
            foreach (OrderDetails orderDetails in orderDetailsList)
            {
                if (orderDetails.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && orderDetails.OrderStatus == OrderStatus.Ordered)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                //display no orders
                Console.WriteLine($"No order to cancel");

            }
            else
            {
                //display order history
                foreach (OrderDetails order in orderDetailsList)
                {
                    if (order.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                    {
                        Console.WriteLine($"{order.OrderID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder:dd/MM/yyyy}|{order.OrderStatus}");
                    }
                }
                //get Order id
                Console.Write($"Enter order ID: ");
                string orderID = Console.ReadLine().ToUpper();
                bool flag1 = true;
                foreach (OrderDetails order in orderDetailsList)
                {
                    //validate order id
                    if (order.OrderID.Equals(orderID) && order.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                    {
                        flag1 = false;
                        //change status to cancel
                        order.OrderStatus = OrderStatus.Cancelled;
                        //return amount to user
                        currentLoggedInCustomer.WalletRecharge(order.TotalPrice);
                        //return food items to food details
                        foreach (ItemDetails item in itemDetailsList)
                        {
                            if (order.OrderID.Equals(item.OrderID))
                            {
                                foreach (FoodDetails foodDetails in foodDetailsList)
                                {
                                    if (item.FoodID.Equals(foodDetails.FoodID))
                                    {
                                        foodDetails.QuantityAvailable += item.PurchaseCount;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
                if (flag1)
                {
                    //display invalid
                    Console.WriteLine($"Invalid order ID");

                }
            }
        }//Cancel order ends

        //Modify order
        public static void ModifyOrder()
        {
            bool flag = true;
            //check if user has orders
            foreach (OrderDetails orderDetails in orderDetailsList)
            {

                if (orderDetails.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && orderDetails.OrderStatus == OrderStatus.Ordered)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                //display no orders
                Console.WriteLine($"No order to cancel");

            }
            else
            {
                //display order history
                foreach (OrderDetails order in orderDetailsList)
                {
                    if (order.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                    {
                        Console.WriteLine($"{order.OrderID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder:dd/MM/yyyy}|{order.OrderStatus}");
                    }
                }
                //get order id 
                Console.Write($"Enter order ID: ");
                string orderID = Console.ReadLine().ToUpper();
                bool flag1 = true;
                foreach (OrderDetails order in orderDetailsList)
                {
                    //validate order id
                    if (order.OrderID.Equals(orderID) && order.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                    {
                        flag1 = false;
                        //display item details
                        foreach (ItemDetails item in itemDetailsList)
                        {
                            if (item.OrderID.Equals(order.OrderID))
                            {
                                Console.WriteLine($"{item.ItemID}|{item.OrderID}|{item.FoodID}|{item.PurchaseCount}|{item.PriceOfOrder}");
                            }
                        }
                        //get item id
                        Console.Write($"Enter Item ID: ");
                        string itemID = Console.ReadLine().ToUpper();
                        bool flag2 = true;
                        foreach (ItemDetails itemDetails in itemDetailsList)
                        {
                            //validate item id
                            if (itemID.Equals(itemDetails.ItemID))
                            {
                                flag2 = false;
                                //get new quantity
                                int newQuantity;
                                Console.Write($"Enter new quantity: ");
                                bool isNewQuantityValid = int.TryParse(Console.ReadLine(), null, out newQuantity);
                                while (!isNewQuantityValid || !(newQuantity > 0))
                                {
                                    Console.WriteLine("Enter valid Number");
                                    Console.Write("Enter quantity: ");
                                    isNewQuantityValid = int.TryParse(Console.ReadLine(), null, out newQuantity);

                                }
                                foreach (FoodDetails food in foodDetailsList)
                                {
                                    if (itemDetails.FoodID.Equals(food.FoodID))
                                    {
                                        if (newQuantity > food.QuantityAvailable)
                                        {
                                            Console.WriteLine($"Food Quantity unavailable. we have {food.QuantityAvailable} {food.FoodName}");
                                        }
                                        else
                                        {

                                            int oldQuantity = itemDetails.PurchaseCount;
                                            double oldTotalPrice = order.TotalPrice;
                                            //get quantity difference
                                            int quantityDifference = newQuantity - oldQuantity;
                                            //calculate new item price
                                            double newItemPrice = food.PricePerQuantity * quantityDifference;
                                            //check user has balance
                                            if (newItemPrice > currentLoggedInCustomer.WalletBalance)
                                            {
                                                //diplay insufficient balance
                                                Console.WriteLine($"Insufficient balance");
                                                return;
                                            }
                                            else
                                            {
                                                if (quantityDifference > 0)
                                                {
                                                    //deduct amount from user
                                                    currentLoggedInCustomer.DeductBalance(newItemPrice);
                                                    //update total price
                                                    order.TotalPrice += newItemPrice;
                                                    //reduce food items
                                                    food.QuantityAvailable -= quantityDifference;
                                                    //update purchase count
                                                    itemDetails.PurchaseCount = newQuantity;
                                                    //diplay user successfull modification
                                                    Console.WriteLine($"Order ID {order.OrderID} Modified succesfully");
                                                    return;
                                                }
                                                else
                                                {
                                                    //return amount to user
                                                    currentLoggedInCustomer.WalletRecharge(-newItemPrice);
                                                    //update total price
                                                    order.TotalPrice += newItemPrice;
                                                    //return quantity
                                                    food.QuantityAvailable -= quantityDifference;
                                                    //update purchase count
                                                    itemDetails.PurchaseCount = newQuantity;
                                                    //diplay user successfull modification
                                                    Console.WriteLine($"Order ID {order.OrderID} Modified succesfully");
                                                    return;

                                                }

                                            }

                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (flag2)
                        {
                            //display invalid item id
                            Console.WriteLine($"Invalid item ID");
                        }

                        break;
                    }
                }
                if (flag1)
                {
                    //diplay invalid order id
                    Console.WriteLine($"Invalid order ID");

                }
            }
        }//Modify order ends

        //Order History
        public static void OrderHistory()
        {
            bool flag = true;
            //check if user has orders
            foreach (OrderDetails orderDetails in orderDetailsList)
            {
                if (orderDetails.CustomerID.Equals(currentLoggedInCustomer.CustomerID))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                //display no orders
                Console.WriteLine($"No order history");

            }
            else
            {
                //display order history
                foreach (OrderDetails order in orderDetailsList)
                {
                    if (order.CustomerID.Equals(currentLoggedInCustomer.CustomerID))
                    {
                        Console.WriteLine($"{order.OrderID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder:dd/MM/yyyy}|{order.OrderStatus}");
                    }
                }
            }
        }//Order History ends

        //Recharge wallet
        public static void RechargeWallet()
        {
            //ask user to recharge
            Console.Write($"Do you want to recharge: ");
            string choice = Console.ReadLine();
            //check user wants to recharge
            if (choice == "yes")
            {
                //get amount from user

                double walletBalance;
                Console.Write($"Enter the amount to recharge: ");
                bool iswalletBalanceValid = double.TryParse(Console.ReadLine(), null, out walletBalance);
                while (!iswalletBalanceValid || !(walletBalance > 0))
                {
                    Console.WriteLine("Enter valid Number");
                    Console.Write($"Enter the amount to recharge: ");
                    iswalletBalanceValid = double.TryParse(Console.ReadLine(), null, out walletBalance);

                }
                //recharge and display balance to user
                Console.WriteLine($"{walletBalance} Recharge successfull.\nYour balance: {currentLoggedInCustomer.WalletRecharge(walletBalance)}");

            }

        }//Recharge wallet ends

        //ShowWalletBalance
        public static void ShowWalletBalance()
        {
            //display wallet balance
            Console.WriteLine($"Your balance is {currentLoggedInCustomer.WalletBalance}");

        }//ShowWalletBalance ends


        //default data 
        public static void DefaultData()
        {
            CustomerDetails customer1 = new CustomerDetails(10000, "Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmail.com", "Chennai");
            CustomerDetails customer2 = new CustomerDetails(15000, "Baskaran", "Sethurajan", Gender.Male, "847575775", new DateTime(1999, 11, 11), "baskaran@gmail.com", "Chennai");
            customerDetailsList.Add(customer1);
            customerDetailsList.Add(customer2);

            FoodDetails food1 = new FoodDetails("Chicken Briyani 1Kg", 100, 12);
            FoodDetails food2 = new FoodDetails("Mutton Briyani 1Kg", 150, 10);
            FoodDetails food3 = new FoodDetails("Veg Full Meals", 80, 30);
            FoodDetails food4 = new FoodDetails("Noodles", 100, 40);
            FoodDetails food5 = new FoodDetails("Dosa", 40, 40);
            FoodDetails food6 = new FoodDetails("Idly (2 pieces)", 20, 50);
            FoodDetails food7 = new FoodDetails("Pongal", 40, 20);
            FoodDetails food8 = new FoodDetails("Vegetable Briyani", 80, 15);
            FoodDetails food9 = new FoodDetails("Lemon Rice", 50, 30);
            FoodDetails food10 = new FoodDetails("Veg Pulav", 120, 30);
            FoodDetails food11 = new FoodDetails("Chicken 65 (200 Grams)", 75, 30);

            foodDetailsList.AddRange(new CustomList<FoodDetails> { food1, food2, food3, food4, food5, food6, food7, food8, food9, food10, food11 });

            OrderDetails order1 = new OrderDetails("CID1001", 580, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1002", 870, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order3 = new OrderDetails("CID1001", 820, new DateTime(2022, 11, 26), OrderStatus.Cancelled);

            orderDetailsList.Add(order1);
            orderDetailsList.Add(order2);
            orderDetailsList.Add(order3);

            ItemDetails item1 = new ItemDetails("OID3001", "FID2001", 2, 200);
            ItemDetails item2 = new ItemDetails("OID3001", "FID2002", 2, 300);
            ItemDetails item3 = new ItemDetails("OID3001", "FID2003", 1, 80);
            ItemDetails item4 = new ItemDetails("OID3002", "FID2001", 1, 100);
            ItemDetails item5 = new ItemDetails("OID3002", "FID2002", 4, 600);
            ItemDetails item6 = new ItemDetails("OID3002", "FID2010", 1, 120);
            ItemDetails item7 = new ItemDetails("OID3002", "FID2009", 1, 50);
            ItemDetails item8 = new ItemDetails("OID3003", "FID2002", 2, 300);
            ItemDetails item9 = new ItemDetails("OID3003", "FID2008", 4, 320);
            ItemDetails item10 = new ItemDetails("OID3003", "FID2001", 2, 200);

            itemDetailsList.AddRange(new CustomList<ItemDetails> { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10 });
        }
    }
}