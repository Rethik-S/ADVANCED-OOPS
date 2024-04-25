using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreApplication
{
    public class CustomerDetails : PersonalDetails, IBalance
    {
        //field
        // <summary>
        /// s_customerID field used to increment a CustomerID of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        private static int s_customerID = 1000;
        // <summary>
        /// _balance field used to hold customer balance of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        private double _balance;


        //auto property
         /// <summary>
        /// CustomerID Property used to hold a  Customer ID of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        public string CustomerID { get; }

        /// <summary>
        /// WalletBalance Property used to hold a  Customer Wallet Balance of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        public double WalletBalance { get { return _balance; } set { _balance = value; } }

        //constructor

        /// <summary>
        /// Constructor CustomerDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="walletBalance">walletBalance used to store data in the associated property</param>
        /// <param name="name">name used to store data in the associated property</param>
        /// <param name="fatherName">fatherName used to store data in the associated property</param>
        /// <param name="gender">gender used to store data in the associated property</param>
        /// <param name="mobile">mobile used to store data in the associated property</param>
        /// <param name="dOB">dOB used to store data in the associated property</param>
        /// <param name="mailID">mailID used to store data in the associated property</param>
        /// <returns></returns>
        public CustomerDetails(double walletBalance, string name, string fatherName, Gender gender, string mobile, DateTime dOB, string mailID) : base(name, fatherName, gender, mobile, dOB, mailID)
        {
            s_customerID++;
            CustomerID = "CID" + s_customerID;

            WalletBalance = walletBalance;
        }

        public CustomerDetails(string user)
        {
            string[] values = user.Split(",");
            s_customerID = int.Parse(values[0].Remove(0,3));
            CustomerID = values[0];
            WalletBalance = double.Parse(values[1]);
            Name = values[2];
            FatherName = values[3];
            Gender = Enum.Parse<Gender>(values[4]);
            Mobile = values[5];
            DOB = DateTime.ParseExact(values[6],"dd/MM/yyyy",null);
            MailID = values[7];
        }

        //methods
        public double WalletRecharge(double amount)
        {
            _balance += amount;
            return WalletBalance;
        }

        public double DeductBalance(double amount)
        {
            _balance -= amount;
            return WalletBalance;
        }

    }
}