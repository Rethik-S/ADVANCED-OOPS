using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreApplication
{
    public static class Operations
    {
        //local/global static customer details
        static CustomerDetails currentLoggedInCustomer;

        //static class creation
        public static CustomList<CustomerDetails> customerDetailsList = new CustomList<CustomerDetails>();
        public static CustomList<ProductDetails> productDetailsList = new CustomList<ProductDetails>();
        public static CustomList<BookingDetails> bookingDetailsList = new CustomList<BookingDetails>();
        public static CustomList<OrderDetails> orderDetailsList = new CustomList<OrderDetails>();


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
            CustomerDetails customer = new CustomerDetails(walletBalance, name, fatherName, gender, mobile, dob, mailID);
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
                Console.WriteLine($"1. Show Profile\n2. show Product details\n3. Wallet recharge\n4. Take Order\n5. Modify Order \n6. Cancel\n7. Show Balance\n8. Exit");

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
                            ShowProductDetails();
                            break;
                        }
                    case "3":
                        {
                            RechargeWallet();
                            break;
                        }
                    case "4":
                        {
                            TakeOrder();
                            break;
                        }
                    case "5":
                        {
                            ModifyOrder();
                            break;
                        }
                    case "6":
                        {
                            CancelOrder();
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
            Console.WriteLine($"{currentLoggedInCustomer.CustomerID}|{currentLoggedInCustomer.WalletBalance}|{currentLoggedInCustomer.Name}|{currentLoggedInCustomer.FatherName}|{currentLoggedInCustomer.Gender}|{currentLoggedInCustomer.Mobile}|{currentLoggedInCustomer.DOB:dd/MM/yyyy}|{currentLoggedInCustomer.MailID}|");
        }//ShowProfile ends


        //ShowProductDetails
        public static void ShowProductDetails()
        {
            foreach (ProductDetails product in productDetailsList)
            {
                Console.WriteLine($"{product.ProductID}|{product.ProductName}|{product.QuantityAvailable}|{product.PricePerQuantity}|");
            }
        }//ShowProductDetails ends

        //Order product
        public static void TakeOrder()
        {
            string choice = "yes";
            //create order details to initiate order
            BookingDetails booking = new BookingDetails(currentLoggedInCustomer.CustomerID, 0, DateTime.Now, BookingStatus.Initiated);
            //create local order list
            CustomList<OrderDetails> localItemsList = new CustomList<OrderDetails>();
            double totalOrderPrice = 0;
            do
            {
                //display product details
                ShowProductDetails();
                //get product id
                Console.Write($"Enter product ID: ");
                string productID = Console.ReadLine().ToUpper();
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
                foreach (ProductDetails product in productDetailsList)
                {
                    //validate product id
                    if (product.ProductID.Equals(productID))
                    {
                        flag = false;
                        //validate quantity is available
                        if (quantity > product.QuantityAvailable)
                        {
                            //display quantity unavailable
                            Console.WriteLine($"product Quantity unavailable. we have {product.QuantityAvailable} {product.ProductName}");
                        }
                        else
                        {
                            //calculate order price
                            double totalItemPrice = quantity * product.PricePerQuantity;
                            //create order object
                            OrderDetails order = new OrderDetails(booking.BookingID, product.ProductID, quantity, totalItemPrice);
                            //reduce available count in product details
                            product.QuantityAvailable -= quantity;
                            //add order to local items list
                            localItemsList.Add(order);
                            //add order price to total bill
                            totalOrderPrice += totalItemPrice;
                        }
                        break;
                    }
                }
                if (flag)
                {
                    //diplay invalid product if
                    Console.WriteLine($"Invalid product ID.");

                }
                //ask user to booking again
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
                                    //return items to Product details
                                    foreach (OrderDetails item in localItemsList)
                                    {
                                        foreach (ProductDetails ProductDetails in productDetailsList)
                                        {
                                            if (item.ProductID.Equals(ProductDetails.ProductID))
                                            {
                                                ProductDetails.QuantityAvailable += item.PurchaseCount;
                                            }
                                        }
                                    }
                                    return;
                                }
                                else
                                {
                                    //update booking price
                                    booking.TotalPrice = totalOrderPrice;
                                    // update booking status
                                    booking.BookingStatus = BookingStatus.Booked;
                                    //deduct amount from user
                                    currentLoggedInCustomer.DeductBalance(totalOrderPrice);
                                    //add local items list to global
                                    orderDetailsList.AddRange(localItemsList);
                                    //add booking to booking details
                                    bookingDetailsList.Add(booking);
                                    //display user booking is placed
                                    Console.WriteLine($"Order is placed. booking ID {booking.BookingID}");
                                    return;
                                }

                            }
                            else
                            {
                                //update booking price
                                booking.TotalPrice = totalOrderPrice;
                                // update booking status
                                booking.BookingStatus = BookingStatus.Booked;
                                //deduct amount from user
                                currentLoggedInCustomer.DeductBalance(totalOrderPrice);
                                //add local items list to global
                                orderDetailsList.AddRange(localItemsList);
                                //add booking to booking details
                                bookingDetailsList.Add(booking);
                                //display user booking is placed
                                Console.WriteLine($"Order is placed. booking ID {booking.BookingID}");
                                return;
                            }
                        }
                    case "no":
                        {
                            //diplay user booking not placed
                            Console.WriteLine($"Order is not placed.");
                            //return items to Product details
                            foreach (OrderDetails item in localItemsList)
                            {
                                foreach (ProductDetails productDetails in productDetailsList)
                                {
                                    if (item.ProductID.Equals(productDetails.ProductID))
                                    {
                                        productDetails.QuantityAvailable += item.PurchaseCount;
                                    }
                                }
                            }
                            return;
                        }
                    default:
                        {
                            Console.WriteLine($"Invalid confirmation. Order is not placed.");
                            //return items to Product details
                            foreach (OrderDetails item in localItemsList)
                            {
                                foreach (ProductDetails productDetails in productDetailsList)
                                {
                                    if (item.ProductID.Equals(productDetails.ProductID))
                                    {
                                        productDetails.QuantityAvailable += item.PurchaseCount;
                                    }
                                }
                            }
                            break;
                        }
                }

            }

        }//Order product ends

        //Cancel booking
        public static void CancelOrder()
        {
            bool flag = true;
            //check if user has orders
            foreach (BookingDetails bookingDetails in bookingDetailsList)
            {
                if (bookingDetails.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && bookingDetails.BookingStatus == BookingStatus.Booked)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                //display no orders
                Console.WriteLine($"No booking to cancel");

            }
            else
            {
                //display booking history
                foreach (BookingDetails booking in bookingDetailsList)
                {
                    if (booking.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && booking.BookingStatus == BookingStatus.Booked)
                    {
                        Console.WriteLine($"{booking.BookingID}|{booking.CustomerID}|{booking.TotalPrice}|{booking.DateOfBooking:dd/MM/yyyy}|{booking.BookingStatus}");
                    }
                }
                //get Order id
                Console.Write($"Enter booking ID: ");
                string bookingID = Console.ReadLine().ToUpper();
                bool flag1 = true;
                foreach (BookingDetails booking in bookingDetailsList)
                {
                    //validate booking id
                    if (booking.BookingID.Equals(bookingID) && booking.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && booking.BookingStatus == BookingStatus.Booked)
                    {
                        flag1 = false;
                        //change status to cancel
                        booking.BookingStatus = BookingStatus.Cancelled;
                        //return amount to user
                        currentLoggedInCustomer.WalletRecharge(booking.TotalPrice);
                        //return Product items to Product details
                        foreach (OrderDetails order in orderDetailsList)
                        {
                            if (booking.BookingID.Equals(order.OrderID))
                            {
                                foreach (ProductDetails productDetails in productDetailsList)
                                {
                                    if (order.ProductID.Equals(productDetails.ProductID))
                                    {
                                        productDetails.QuantityAvailable += order.PurchaseCount;
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
                    Console.WriteLine($"Invalid booking ID");

                }
            }
        }//Cancel order ends

        //Modify order
        public static void ModifyOrder()
        {
            bool flag = true;
            //check if user has orders
            foreach (BookingDetails bookingDetails in bookingDetailsList)
            {

                if (bookingDetails.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && bookingDetails.BookingStatus == BookingStatus.Booked)
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
                foreach (BookingDetails booking in bookingDetailsList)
                {
                    if (booking.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && booking.BookingStatus == BookingStatus.Booked)
                    {
                        Console.WriteLine($"{booking.BookingID}|{booking.CustomerID}|{booking.TotalPrice}|{booking.DateOfBooking:dd/MM/yyyy}|{booking.BookingStatus}");
                    }
                }
                //get booking id 
                Console.Write($"Enter booking ID: ");
                string bookingID = Console.ReadLine().ToUpper();
                bool flag1 = true;
                foreach (BookingDetails booking in bookingDetailsList)
                {
                    //validate booking id
                    if (booking.BookingID.Equals(bookingID) && booking.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && booking.BookingStatus == BookingStatus.Booked)
                    {
                        flag1 = false;
                        //display item details
                        foreach (OrderDetails order in orderDetailsList)
                        {
                            if (order.BookingID.Equals(booking.BookingID))
                            {
                                Console.WriteLine($"{order.OrderID}|{order.OrderID}|{order.ProductID}|{order.PurchaseCount}|{order.PriceOfOrder}");
                            }
                        }
                        //get order id
                        Console.Write($"Enter order ID: ");
                        string orderID = Console.ReadLine().ToUpper();
                        bool flag2 = true;
                        foreach (OrderDetails orderDetails in orderDetailsList)
                        {
                            //validate order id
                            if (orderID.Equals(orderDetails.OrderID))
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
                                foreach (ProductDetails product in productDetailsList)
                                {
                                    if (orderDetails.ProductID.Equals(product.ProductID))
                                    {
                                        if (newQuantity > product.QuantityAvailable)
                                        {
                                            Console.WriteLine($"product Quantity unavailable. we have {product.QuantityAvailable} {product.ProductName}");
                                        }
                                        else
                                        {

                                            int oldQuantity = orderDetails.PurchaseCount;
                                            double oldTotalPrice = booking.TotalPrice;
                                            //get quantity difference
                                            int quantityDifference = newQuantity - oldQuantity;
                                            //calculate new order price
                                            double newItemPrice = product.PricePerQuantity * quantityDifference;
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
                                                    booking.TotalPrice += newItemPrice;
                                                    //reduce product items
                                                    product.QuantityAvailable -= quantityDifference;
                                                    //update purchase count
                                                    orderDetails.PurchaseCount = newQuantity;
                                                    //diplay user successfull modification
                                                    Console.WriteLine($"Order ID {booking.BookingID} Modified succesfully");
                                                    return;
                                                }
                                                else
                                                {
                                                    //return amount to user
                                                    currentLoggedInCustomer.WalletRecharge(-newItemPrice);
                                                    //update total price
                                                    booking.TotalPrice += newItemPrice;
                                                    //return quantity
                                                    product.QuantityAvailable -= quantityDifference;
                                                    //update purchase count
                                                    orderDetails.PurchaseCount = newQuantity;
                                                    //diplay user successfull modification
                                                    Console.WriteLine($"Order ID {booking.BookingID} Modified succesfully");
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
                            //display invalid order id
                            Console.WriteLine($"Invalid order ID");
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


        public static void DefaultData()
        {
            CustomerDetails customer1 = new CustomerDetails(10000, "Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmail.com");
            CustomerDetails customer2 = new CustomerDetails(15000, "Baskaran", "Sethurajan", Gender.Male, "847575775", new DateTime(1999, 11, 11), "ravi@gmail.com");

            customerDetailsList.Add(customer1);
            customerDetailsList.Add(customer2);

            ProductDetails product1 = new ProductDetails("Sugar", 20, 40);
            ProductDetails product2 = new ProductDetails("Rice", 100, 50);
            ProductDetails product3 = new ProductDetails("Milk", 10, 40);
            ProductDetails product4 = new ProductDetails("Coffee", 10, 10);
            ProductDetails product5 = new ProductDetails("Tea", 10, 10);
            ProductDetails product6 = new ProductDetails("Masala Powder", 10, 20);
            ProductDetails product7 = new ProductDetails("Salt", 10, 10);
            ProductDetails product8 = new ProductDetails("Turmeric Powder", 10, 25);
            ProductDetails product9 = new ProductDetails("Chilli Powder", 10, 20);
            ProductDetails product10 = new ProductDetails("Groundnut Oil", 10, 140);

            productDetailsList.AddRange(new CustomList<ProductDetails> { product1, product2, product3, product4, product5, product6, product7, product8, product9, product10 });


            BookingDetails booking1 = new BookingDetails("CID1001", 220, new DateTime(2022, 7, 26), BookingStatus.Booked);
            BookingDetails booking2 = new BookingDetails("CID1002", 400, new DateTime(2022, 7, 26), BookingStatus.Booked);
            BookingDetails booking3 = new BookingDetails("CID1001", 280, new DateTime(2022, 7, 26), BookingStatus.Cancelled);
            BookingDetails booking4 = new BookingDetails("CID1002", 0, new DateTime(2022, 7, 26), BookingStatus.Initiated);

            bookingDetailsList.Add(booking1);
            bookingDetailsList.Add(booking2);
            bookingDetailsList.Add(booking3);
            bookingDetailsList.Add(booking4);

            OrderDetails order1 = new OrderDetails("BID3001", "PID2001", 2, 80);
            OrderDetails order2 = new OrderDetails("BID3001", "PID2002", 2, 100);
            OrderDetails order3 = new OrderDetails("BID3001", "PID2003", 1, 40);
            OrderDetails order4 = new OrderDetails("BID3002", "PID2001", 1, 40);
            OrderDetails order5 = new OrderDetails("BID3002", "PID2002", 4, 200);
            OrderDetails order6 = new OrderDetails("BID3002", "PID2010", 1, 140);
            OrderDetails order7 = new OrderDetails("BID3002", "PID2009", 1, 20);
            OrderDetails order8 = new OrderDetails("BID3003", "PID2002", 2, 100);
            OrderDetails order9 = new OrderDetails("BID3003", "PID2008", 4, 100);
            OrderDetails order10 = new OrderDetails("BID3003", "PID2001", 2, 80);

            orderDetailsList.AddRange(new CustomList<OrderDetails> { order1, order2, order3, order4, order5, order6, order7, order8, order9, order10 });
        }

    }
}