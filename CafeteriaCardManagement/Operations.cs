using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public static class Operations
    {
        //Local/Global Object Creation
        static UserDetails currentLoggedInUser;

        //static custom list creation
        static CustomList<UserDetails> userDetailsList = new CustomList<UserDetails>();
        static CustomList<FoodDetails> foodDetailsList = new CustomList<FoodDetails>();
        static CustomList<OrderDetails> orderDetailsList = new CustomList<OrderDetails>();
        static CustomList<CartItem> cartItemsList = new CustomList<CartItem>();


        //Main menu
        public static void MainMenu()
        {
            System.Console.WriteLine("*********** Welcome to Cafeteria ***********");
            string mainChoice = "yes";
            do
            {
                //Need to show main menu option.
                System.Console.WriteLine("Main menu\n1. User Registration\n2. User Login\n3. Exit");
                //Need to get an input from user and validate.
                System.Console.Write("Select an option: ");
                string mainOption = Console.ReadLine();
                //Need to create main menu structure
                switch (mainOption)
                {
                    case "1":
                        {
                            System.Console.WriteLine("********* User Registration *********");
                            UserRegistration();
                            break;
                        }
                    case "2":
                        {
                            System.Console.WriteLine("********* User Login *********");
                            UserLogin();
                            break;
                        }
                    case "3":
                        {
                            mainChoice = "no";
                            System.Console.WriteLine("Application Exited Successfully.");
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Enter a valid Option");
                            break;
                        }
                }
                //Need to iterate until the option is exit
            } while (mainChoice == "yes");
        }//main menu ends


        //User Registration
        public static void UserRegistration()
        {
            //Need to get required details

            Console.Write("Enter your Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter your Father Name: ");
            string fatherName = Console.ReadLine();

            Console.Write("Enter your Mobile Number: ");
            string mobileNumber = Console.ReadLine();

            Console.Write("Enter your Mail ID: ");
            string mailID = Console.ReadLine();

            Console.Write("Enter gender ( Male or Female or Transgender ): ");
            Gender gender;
            bool isGenderValid = Enum.TryParse(Console.ReadLine(), true, out gender);
            while (!isGenderValid)
            {
                Console.WriteLine("Provide valid gender");
                Console.Write("Enter gender ( Male or Female or Transgender ): ");
                isGenderValid = Enum.TryParse(Console.ReadLine(), true, out gender);
            }

            Console.Write("Enter your Work Station Number: ");
            string workStationNumber = Console.ReadLine();

            double walletBalance;
            Console.Write("Enter amount to deposit in wallet: ");
            bool iswalletBalanceValid = double.TryParse(Console.ReadLine(), null, out walletBalance);
            while (!iswalletBalanceValid || !(walletBalance > 0))
            {
                Console.WriteLine("Enter valid Number");
                Console.Write("Enter amount to deposit in wallet: ");
                iswalletBalanceValid = double.TryParse(Console.ReadLine(), null, out walletBalance);

            }

            //Need to create an object
            UserDetails user = new UserDetails(studentName, fatherName, gender, mobileNumber, mailID, workStationNumber);

            //need to deposit wallet balance 
            user.WalletRecharge(walletBalance);

            //Need to add in the list
            userDetailsList.Add(user);

            //Need to display confirmation message and ID
            System.Console.WriteLine($"User Registered Successfully and User ID is {user.UserID}");

        }//User Registration ends

        //User Login
        public static void UserLogin()
        {
            //Need to get Id input
            System.Console.Write("Enter your User ID: ");
            string userID = Console.ReadLine().ToUpper();
            //Validate by its prescence in list
            bool flag = true;
            foreach (UserDetails user in userDetailsList)
            {
                if (userID.Equals(user.UserID))
                {
                    flag = false;
                    //assigning current user to glabal variable
                    currentLoggedInUser = user;
                    System.Console.WriteLine("Logged In Successfully.");
                    //Need to call sub menu
                    Submenu();
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid ID or ID is not present.");
            }
            //If not - Invalid Valid.
        }//User Login ends

        //Submenu
        public static void Submenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine("********** SubMenu **********");
                //Need to show sub menu option
                System.Console.WriteLine("1. Show My Profile\n2. Food Order\n3. Modify Order\n4. Cancel Order\n5. Order History\n6. Wallet Recharge\n7. Show Wallet Balance\n8. Exit");
                //Getting user option
                System.Console.Write("Select an option: ");
                string subOption = Console.ReadLine();

                //Need to create Sub menu structure
                switch (subOption)
                {
                    case "1":
                        {
                            System.Console.WriteLine("******** Show My Profile ********");
                            ShowMyProfile();
                            break;
                        }
                    case "2":
                        {
                            System.Console.WriteLine("******** Food Order ********");
                            FoodOrder();
                            break;
                        }
                    case "3":
                        {
                            System.Console.WriteLine("******** Modify Order ********");
                            ModifyOrder();
                            break;
                        }
                    case "4":
                        {
                            System.Console.WriteLine("******** Cancel Order ********");
                            CancelOrder();
                            break;
                        }
                    case "5":
                        {
                            System.Console.WriteLine("******** Order History ********");
                            OrderHistory();
                            break;
                        }
                    case "6":
                        {
                            System.Console.WriteLine("******** Wallet Recharge ********");
                            WalletRecharge();
                            break;
                        }
                    case "7":
                        {
                            System.Console.WriteLine("******** Show Wallet Balance ********");
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
                            System.Console.WriteLine("Enter a valid option");
                            break;
                        }
                }
                //Iterate till the option is Exit.

            } while (subChoice == "yes");
        }//Submenu Ends


        //ShowMyProfile
        public static void ShowMyProfile()
        {
            //display user information
            Console.WriteLine($"|{currentLoggedInUser.UserID}|{currentLoggedInUser.Name}|{currentLoggedInUser.FatherName}|{currentLoggedInUser.Mobile}|{currentLoggedInUser.MailID}|{currentLoggedInUser.Gender}|");

        }//ShowMyProfile ens

        //FoodOrder
        public static void FoodOrder()
        {
            //create order object
            OrderDetails order = new OrderDetails(currentLoggedInUser.UserID, DateTime.Now, 0, OrderStatus.Initiated);
            //create local cart item list
            CustomList<CartItem> localCartItemsList = new CustomList<CartItem>();
            string choice = "yes";
            do
            {
                //display food details
                foreach (FoodDetails foodDetails in foodDetailsList)
                {
                    Console.WriteLine($"|{foodDetails.FoodID}|{foodDetails.FoodName}|{foodDetails.FoodPrice}|{foodDetails.AvailableQuantity}|");
                }

                //ask for details of food to order
                Console.Write($"Enter the FoodID: ");
                string foodID = Console.ReadLine().ToUpper();

                Console.Write($"Enter the quantity: ");
                int quantity;
                bool isquantityValid = int.TryParse(Console.ReadLine(), out quantity);
                while (!isquantityValid || !(quantity > 0))
                {
                    Console.WriteLine("Enter valid number as input");
                    Console.Write("Enter the quantity: ");
                    isquantityValid = int.TryParse(Console.ReadLine(), out quantity);
                }

                bool flag = true;
                foreach (FoodDetails foodDetails in foodDetailsList)
                {
                    //if food id found
                    if (foodID.Equals(foodDetails.FoodID))
                    {
                        flag = false;
                        //check quantity is available
                        if (quantity > foodDetails.AvailableQuantity)
                        {
                            Console.WriteLine($"You are asking more than the available quatity.\nWe have {foodDetails.AvailableQuantity} {foodDetails.FoodName}'s ");
                            break;
                        }
                        else
                        {
                            //calculate price
                            double price = foodDetails.FoodPrice * quantity;
                            //reduce quantity from food details
                            foodDetails.AvailableQuantity -= quantity;
                            //create cart item
                            CartItem cartItem = new CartItem(order.OrderID, foodDetails.FoodID, price, quantity);
                            //add cart item to local list
                            localCartItemsList.Add(cartItem);

                        }
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine($"Enter a valid food ID");
                    return;
                }
                //ask user to order another food item
                Console.Write($"Do you want order again? ( yes / no ): ");
                choice = Console.ReadLine().ToLower();
            } while (choice == "yes");
            //confirm the purchase
            Console.Write($"Do you confirm the purchase of wish list ( yes / no ): ");
            string processOrder = Console.ReadLine().ToLower();
            if (processOrder == "yes")
            {
                //calculate total price of the order
                double totalPrice = 0;
                foreach (CartItem cartItem in localCartItemsList)
                {
                    totalPrice += cartItem.OrderPrice;
                }
                //check user have required balance
                if (totalPrice > currentLoggedInUser.WalletBalance)
                {
                    Console.WriteLine($"Insufficient balance to purchase.");
                    //ask user to recharge
                    Console.Write("Are you willing to recharge: ");
                    string recharge = Console.ReadLine().ToLower();
                    if (recharge == "no")
                    {
                        Console.WriteLine($"Exiting without Order due to insufficient balance.");
                        //return item to food details
                        foreach (CartItem Item in localCartItemsList)
                        {
                            foreach (FoodDetails food in foodDetailsList)
                            {
                                if (Item.FoodID.Equals(food.FoodID))
                                {
                                    food.AvailableQuantity += Item.OrderQuantity;
                                    break;
                                }
                            }
                        }
                        return;
                    }
                    else if (recharge == "yes")
                    {
                        //ask amount to recharge
                        double amount;
                        Console.Write($"Enter the amount (above or equal to {totalPrice}) : ");
                        bool isAmountValid = double.TryParse(Console.ReadLine(), null, out amount);
                        while (!isAmountValid || !(amount > 0))
                        {
                            Console.WriteLine("Enter valid Number");
                            Console.Write($"Enter the amount (above or equal to {totalPrice}) : ");
                            isAmountValid = double.TryParse(Console.ReadLine(), null, out amount);

                        }
                        //check amount is higher than price
                        if (amount >= totalPrice)
                        {
                            //recherge the user
                            currentLoggedInUser.WalletRecharge(amount);
                            //deduct amount for the bill
                            currentLoggedInUser.DeductAmount(totalPrice);
                            //add the cart items to global list
                            cartItemsList.AddRange(localCartItemsList);
                            //update order price and status
                            order.TotalPrice = totalPrice;
                            order.OrderStatus = OrderStatus.Ordered;
                            //add order to list
                            orderDetailsList.Add(order);
                            //display order placed
                            Console.WriteLine($"Order placed successfully, and OrderID is {order.OrderID}.");
                            return;
                        }
                        else
                        {
                            //recharge user
                            currentLoggedInUser.WalletRecharge(amount);
                            Console.WriteLine($"Exiting without Order due to insufficient balance.");
                            //return items to food details
                            foreach (CartItem cartItem in localCartItemsList)
                            {
                                foreach (FoodDetails foodDetails in foodDetailsList)
                                {
                                    if (cartItem.FoodID.Equals(foodDetails.FoodID))
                                    {
                                        foodDetails.AvailableQuantity += cartItem.OrderQuantity;
                                        break;
                                    }
                                }
                            }
                            return;

                        }
                    }
                }
                else
                {
                    //deduct amount for the bill
                    currentLoggedInUser.DeductAmount(totalPrice);
                    //add the cart items to global list
                    cartItemsList.AddRange(localCartItemsList);
                    //update order price and status
                    order.TotalPrice = totalPrice;
                    order.OrderStatus = OrderStatus.Ordered;
                    //add order to list
                    orderDetailsList.Add(order);
                    //display order placed
                    Console.WriteLine($"Order placed successfully, and OrderID is {order.OrderID}.");
                    return;
                }

            }
            else
            {
                //return items to food details
                foreach (CartItem cartItem in localCartItemsList)
                {
                    foreach (FoodDetails foodDetails in foodDetailsList)
                    {
                        if (cartItem.FoodID.Equals(foodDetails.FoodID))
                        {
                            foodDetails.AvailableQuantity += cartItem.OrderQuantity;
                            break;
                        }
                    }
                }
                Console.WriteLine($"Order is not placed.");

            }



        } //FoodOrder ends

        //ModifyOrder
        public static void ModifyOrder()
        {
            bool flag1 = true;
            //check user has active orders
            foreach (OrderDetails order in orderDetailsList)
            {
                if (order.UserID.Equals(currentLoggedInUser.UserID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag1 = false;
                    break;
                }
            }
            if (flag1)
            {
                Console.WriteLine($"you have no active orders to modify.");
            }
            else
            {
                //display user active orders

                foreach (OrderDetails order in orderDetailsList)
                {
                    if (order.UserID.Equals(currentLoggedInUser.UserID) && order.OrderStatus == OrderStatus.Ordered)
                    {
                        Console.WriteLine($"|{order.OrderID}|{order.UserID}|{order.OrderDate:dd/MM/yyyy}|{order.TotalPrice}|{order.OrderStatus}|");
                    }
                }
                //ask for order id
                Console.Write($"Enter the Order ID: ");
                string orderId = Console.ReadLine().ToUpper();
                bool flag2 = true;
                foreach (OrderDetails order in orderDetailsList)
                {
                    //check order id
                    if (order.UserID.Equals(currentLoggedInUser.UserID) && orderId.Equals(order.OrderID) && order.OrderStatus == OrderStatus.Ordered)
                    {
                        flag2 = false;
                        double oldTotalPrice = order.TotalPrice;
                        //display the item details
                        foreach (CartItem item in cartItemsList)
                        {
                            if (order.OrderID.Equals(item.OrderID))
                            {
                                Console.WriteLine($"{item.ItemID}|{item.OrderID}|{item.FoodID}|{item.OrderPrice}|{item.OrderQuantity}");
                            }
                        }
                        //ask for item id
                        Console.Write($"Enter the Item ID: ");
                        string itemID = Console.ReadLine().ToUpper();
                        bool flag3 = true;
                        bool flag4 = true;
                        double newOrderPrice = 0;
                        double oldOrderPrice = 0;
                        int oldAvailableQuantity = 0;
                        int oldQuantity = 0;
                        foreach (CartItem item in cartItemsList)
                        {
                            if (itemID.Equals(item.ItemID))
                            {
                                flag3 = false;
                                //ask for quantity to change
                                Console.Write($"Enter the quantity: ");
                                int quantity;
                                bool isquantityValid = int.TryParse(Console.ReadLine(), out quantity);
                                while (!isquantityValid || !(quantity > 0))
                                {
                                    Console.WriteLine("Enter valid number as input");
                                    Console.Write("Enter the quantity: ");
                                    isquantityValid = int.TryParse(Console.ReadLine(), out quantity);
                                }
                                oldQuantity = item.OrderQuantity;
                                oldOrderPrice = item.OrderPrice;

                                foreach (FoodDetails foodDetails in foodDetailsList)
                                {
                                    if (item.FoodID.Equals(foodDetails.FoodID))
                                    {
                                        //check for availabilty of quantity
                                        if (foodDetails.AvailableQuantity >= quantity)
                                        {
                                            flag4 = false;
                                            //get old available quantity
                                            oldAvailableQuantity = foodDetails.AvailableQuantity;
                                            //add the previous ordered quantity
                                            foodDetails.AvailableQuantity += oldQuantity;
                                            //reduce the qquantity changed
                                            foodDetails.AvailableQuantity -= quantity;
                                            //calculate price
                                            item.OrderPrice = quantity * foodDetails.FoodPrice;
                                            //get new order price
                                            newOrderPrice = item.OrderPrice;
                                            break;
                                        }
                                        else
                                        {
                                            flag3 = true;
                                            break;
                                        }
                                    }
                                }
                                //get item quantity
                                item.OrderQuantity = quantity;
                                break;
                            }
                        }
                        if (flag3)
                        {
                            if (flag3 && flag4)
                            {
                                foreach (CartItem item in cartItemsList)
                                {
                                    if (itemID.Equals(item.ItemID))
                                    {
                                        //return old quantity
                                        item.OrderQuantity = oldQuantity;
                                        break;
                                    }
                                }
                                Console.WriteLine($"Invalid quantity provided.");
                            }
                            else
                            {
                                Console.WriteLine($"Invaild cart item ID.");
                            }
                        }
                        else
                        {
                            //reduce the old order price
                            order.TotalPrice -= oldOrderPrice;
                            //add the new order modified price
                            order.TotalPrice += newOrderPrice;
                            //get new total price
                            double newTotalPrice = order.TotalPrice;
                            //calculate the total diffrence
                            double totalDifference = newOrderPrice - oldOrderPrice;
                            if (totalDifference > 0)
                            {
                                //check balance
                                if (totalDifference > currentLoggedInUser.WalletBalance)
                                {
                                    Console.WriteLine($"insufficient balance. Recharge and try again.");
                                    //return to old order details
                                    foreach (CartItem item in cartItemsList)
                                    {
                                        if (itemID.Equals(item.ItemID))
                                        {
                                            foreach (FoodDetails foodDetails in foodDetailsList)
                                            {
                                                if (item.FoodID.Equals(foodDetails.FoodID))
                                                {
                                                    foodDetails.AvailableQuantity = oldAvailableQuantity;
                                                    break;
                                                }
                                            }
                                            item.OrderPrice = oldOrderPrice;
                                            item.OrderQuantity = oldQuantity;
                                            break;
                                        }
                                    }
                                    order.TotalPrice = oldTotalPrice;
                                    Console.WriteLine($"Order modification failed.");
                                }
                                else
                                {
                                    //reduce amount to new ordered items
                                    currentLoggedInUser.DeductAmount(totalDifference);
                                    //add new total price
                                    order.TotalPrice = newTotalPrice;
                                    Console.WriteLine($"Order modified successfully.");
                                    return;
                                }
                            }
                            else
                            {
                                //return the amount if items are returned
                                Console.WriteLine($"Amount refunded = {-totalDifference}.");
                                currentLoggedInUser.WalletRecharge(-totalDifference);
                                Console.WriteLine($"Order modified successfully.");
                            }
                            break;
                        }
                    }
                }
                if (flag2)
                {
                    Console.WriteLine($"Enter a valid Order ID.");
                }

            }

        }//ModifyOrder ends

        //CancelOrder
        public static void CancelOrder()
        {
            bool flag1 = true;
            //check for active orders
            foreach (OrderDetails order in orderDetailsList)
            {
                if (order.UserID.Equals(currentLoggedInUser.UserID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag1 = false;
                    Console.WriteLine($"|{order.OrderID}|{order.UserID}|{order.OrderDate:dd/MM/yyyy}|{order.TotalPrice}|{order.OrderStatus}|");
                }
            }
            if (flag1)
            {
                Console.WriteLine($"you have no active orders to cancel.");


            }
            else
            {
                //ask for order id
                Console.Write($"Enter the Order ID: ");
                string orderID = Console.ReadLine().ToUpper();
                bool flag = true;
                foreach (OrderDetails order in orderDetailsList)
                {
                    if (orderID.Equals(order.OrderID) && order.OrderStatus == OrderStatus.Ordered)
                    {
                        flag = false;
                        //change order status to cancel
                        order.OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine($"Amount refunded: {order.TotalPrice}\nyour balance: {currentLoggedInUser.WalletRecharge(order.TotalPrice)}");
                        foreach (CartItem item in cartItemsList)
                        {
                            if (order.OrderID.Equals(item.OrderID))
                            {
                                //return food items
                                foreach (FoodDetails food in foodDetailsList)
                                {
                                    if (food.FoodID.Equals(item.FoodID))
                                    {
                                        food.AvailableQuantity += item.OrderQuantity;
                                    }
                                }
                            }
                        }
                        Console.WriteLine($"Your order is cancelled.");

                    }
                }
                if (flag)
                {
                    Console.WriteLine($"Enter valid Order ID");

                }
            }
        }//cancel order ends

        //OrderHistory
        public static void OrderHistory()
        {
            bool flag = true;
            //check user have orders
            foreach (OrderDetails order in orderDetailsList)
            {
                if (order.UserID.Equals(currentLoggedInUser.UserID))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine($"you have no orders.");
            }
            else
            {
                //display order details
                foreach (OrderDetails order in orderDetailsList)
                {
                    if (order.UserID.Equals(currentLoggedInUser.UserID))
                    {
                        Console.WriteLine($"|{order.OrderID}|{order.UserID}|{order.OrderDate:dd/MM/yyyy}|{order.TotalPrice}|{order.OrderStatus}|");
                    }
                }
            }

        }//OrderHistory ends

        //WalletRecharge
        public static void WalletRecharge()
        {
            //ask the amount to recharge
            double amount;
            Console.Write("Enter amount to recharge wallet: ");
            bool isAmountValid = double.TryParse(Console.ReadLine(), null, out amount);
            while (!isAmountValid || !(amount > 0))
            {
                Console.WriteLine("Enter valid Number");
                Console.Write("Enter amount to recharge wallet: ");
                isAmountValid = double.TryParse(Console.ReadLine(), null, out amount);
            }
            //recharge
            Console.WriteLine($"your balance: {currentLoggedInUser.WalletRecharge(amount)}");

        }//WalletRecharge ends

        //ShowWalletBalance
        public static void ShowWalletBalance()
        {
            //display balance
            Console.WriteLine($"Your wallet balance : {currentLoggedInUser.WalletBalance}");

        }//ShowWalletBalance ends


        //AddDefaultData
        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("Ravichandran", "Ettapparajan", Gender.Male, "8857777575", "ravi@gmail.com", "WS101");
            user1.WalletRecharge(400);
            UserDetails user2 = new UserDetails("Baskaran", "Sethurajan", Gender.Male, "9577747744", "baskaran@gmail.com", "WS105");
            user2.WalletRecharge(500);

            userDetailsList.AddRange(new CustomList<UserDetails> { user1, user2 });

            FoodDetails foodDetails1 = new FoodDetails("Coffee", 20, 100);
            FoodDetails foodDetails2 = new FoodDetails("Tea", 15, 100);
            FoodDetails foodDetails3 = new FoodDetails("Biscuit", 10, 100);
            FoodDetails foodDetails4 = new FoodDetails("Juice", 50, 100);
            FoodDetails foodDetails5 = new FoodDetails("Puff", 40, 100);
            FoodDetails foodDetails6 = new FoodDetails("Milk", 10, 100);
            FoodDetails foodDetails7 = new FoodDetails("Popcorn", 20, 20);

            foodDetailsList.AddRange(new CustomList<FoodDetails> { foodDetails1, foodDetails2, foodDetails3, foodDetails4, foodDetails5, foodDetails6, foodDetails7 });

            OrderDetails order1 = new OrderDetails("SF1001", new DateTime(2022, 6, 15), 70, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("SF1002", new DateTime(2022, 6, 15), 100, OrderStatus.Ordered);

            orderDetailsList.Add(order1);
            orderDetailsList.Add(order2);

            CartItem cartItem1 = new CartItem("OID1001", "FID101", 20, 1);
            CartItem cartItem2 = new CartItem("OID1001", "FID103", 10, 1);
            CartItem cartItem3 = new CartItem("OID1001", "FID105", 40, 1);
            CartItem cartItem4 = new CartItem("OID1002", "FID103", 10, 1);
            CartItem cartItem5 = new CartItem("OID1002", "FID104", 50, 1);
            CartItem cartItem6 = new CartItem("OID1002", "FID105", 40, 1);

            cartItemsList.AddRange(new CustomList<CartItem> { cartItem1, cartItem2, cartItem3, cartItem4, cartItem5, cartItem6 });

        }//AddDefaultData ends






    }
}