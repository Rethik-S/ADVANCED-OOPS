using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetails : PersonalDetails, IWallet
    {
        //field
         /// <summary>
        /// s_userID field used to increment a UserID of the instance of <see cref="UserDetails"/>
        /// </summary>
        private static int s_userID = 1000;
         /// <summary>
        /// _balance field used to hold a User balance of the instance of <see cref="UserDetails"/>
        /// </summary>
        private double _balance;



        //Auto property
         /// <summary>
        /// Name Property used to hold a User's Name of the instance of <see cref="UserDetails"/>
        /// </summary>
        public string UserID { get; }//read only property

        /// <summary>
        /// WalletBalance Property used to hold a User's Wallet Balance of the instance of <see cref="UserDetails"/>
        /// </summary>
        public double WalletBalance { get { return _balance; } }//read only property


        //constructor 

        /// <summary>
        /// Constructor UserDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="name">name used to store data in the associated property</param>
        /// <param name="age">age used to store data in the associated property</param>
        /// <param name="city">city used to store data in the associated property</param>
        /// <param name="phoneNumber">phoneNumber used to store data in the associated property</param>
        /// <param name="balance">balance used to store data in the associated property</param>
        /// <returns></returns>
        public UserDetails(string name, string age, string city, string phoneNumber, double balance) : base(name, age, city, phoneNumber)
        {
            s_userID++;
            UserID = "UID" + s_userID;

            _balance = balance;
        }
        public UserDetails(string user)
        {
            string[] values = user.Split(",");
            s_userID=int.Parse(values[0].Remove(0,3));
            UserID = values[0];
            Name = values[1];
            Age = values[2];
            City = values[3];
            PhoneNumber = values[4];
            _balance = double.Parse(values[5]);
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