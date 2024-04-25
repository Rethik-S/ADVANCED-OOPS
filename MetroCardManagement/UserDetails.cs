using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {

        //field

        /// <summary>
        /// Static field s_cardNumber used to autoincrement CardNumber of the instance of <see cref="UserDetails"/>
        /// </summary>
        private static int s_cardNumber = 1000;

        /// <summary>
        /// field _balance used to hold user's balance of the instance of <see cref="UserDetails"/>
        /// </summary>
        private double _balance = 0;



        //Auto Property
        /// <summary>
        /// CardNumber Property used to hold a User's Card Number of the instance of <see cref="UserDetails"/>
        /// </summary>
        public string CardNumber { get; } //Read only property

        
        /// <summary>
        ///  Balance Property used to hold a User's Balance of the instance of <see cref="UserDetails"/>
        /// </summary>
        public double Balance { get { return _balance; } set { _balance = value; } }


        /// <summary>
        /// Constructor UserDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="userName">userName used to store data in the associated property</param>
        /// <param name="phoneNumber">phoneNumber used to store data in the associated property</param>
        /// <param name="balance">balance used to store the data in the associated property</param>
        /// <returns>Instance of <see cref="UserDetails"/></returns>
        public UserDetails(string userName, string phoneNumber, double balance) : base(userName, phoneNumber)
        {
            //Auto Incerementation
            s_cardNumber++;
            CardNumber = "CMRL" + s_cardNumber;

            WalletRecharge(balance);
        }

        /// <summary>
        /// Constructor UserDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="user">user used to store data in the associated property</param>
        /// <returns>Instance of <see cref="UserDetails"/></returns>
        public UserDetails(string user) : base()
        {
            string[] values = user.Split(",");
            s_cardNumber = int.Parse(values[0].Remove(0, 4));
            CardNumber = values[0];
            UserName = values[1];
            PhoneNumber = values[2];
            WalletRecharge(double.Parse(values[3]));
        }


        //Methods
        /// <summary>
        /// WalletRecharge used to Recharge wallet of the Instance of <see cref="UserDetails"/>
        /// </summary>
        /// <param name="amount">amount used to pass the associated data</param>
        /// <returns>Balance of a Instance of <see cref="UserDetails"/></returns>
        public double WalletRecharge(double amount)
        {
            _balance += amount;
            return Balance;
        }

        /// <summary>
        /// DeductBalance used to Deduct amount from  wallet of the Instance of <see cref="UserDetails"/>
        /// </summary>
        /// <param name="amount">amount used to pass the associated data</param>
        /// <returns>Balance of a Instance of <see cref="UserDetails"/></returns>
        public double DeductBalance(double amount)
        {
            _balance -= amount;
            return Balance;
        }
    }
}