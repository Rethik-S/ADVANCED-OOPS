using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {

        /*
            •	UserID (Auto – SF1001)
            •	WorkStationNumber
            •	Field: _balance
            •	Read only property: WalletBalance.
            Methods:
            •	WalletRecharge, DeductAmount	
        */


        //field

        /// <summary>
        /// Static field s_userID used to autoincrement UserID of the instance of <see cref="UserDetails"/>
        /// </summary>
        private static int s_userID = 1000;

        /// <summary>
        /// field _balance used to hold User's balance of the instance of <see cref="UserDetails"/>
        /// </summary>
        private double _balance;

        //Auto Property

        /// <summary>
        /// UserID Property used to hold a user's ID of the instance of <see cref="UserDetails"/>
        /// </summary>
        public string UserID { get; }//read only property

        /// <summary>
        /// WorkStationNumber Property used to hold a user's WorkStation Number of the instance of <see cref="UserDetails"/>
        /// </summary>
        public string WorkStationNumber { get; set; }
        /// <summary>
        /// WalletBalance Property used to hold a user's Wallet Balance of the instance of <see cref="UserDetails"/>
        /// </summary>
        public double WalletBalance { get { return _balance; } }//read only property

        //Constructor

        /// <summary>
        /// Constructor UserDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="name">name parameter used to assign value to its associated property</param>
        /// <param name="fatherName">fatherName parameter used to assign value to its associated property</param>
        /// <param name="gender">gender parameter used to assign value to its associated property</param>
        /// <param name="mobile">mobile parameter used to assign value to its associated property</param>
        /// <param name="mailID">mailID parameter used to assign value to its associated property</param>
        /// <param name="workStationNumber">workStationNumber parameter used to assign value to its associated property</param>
        /// <returns></returns>
        public UserDetails(string name, string fatherName, Gender gender, string mobile, string mailID, string workStationNumber) : base(name, fatherName, gender, mobile, mailID)
        {
            //Auto incrementation
            s_userID++;
            UserID = "SF" + s_userID;

            WorkStationNumber = workStationNumber;
        }

        //Methods
        /// <summary>
        /// Method WalletRecharge used to Recharge Wallet of instance of <see cref="UserDetails"/>
        /// </summary>
        /// <param name="amount">recharge amount</param>
        /// <returns>balance of user</returns>
        public double WalletRecharge(double amount)
        {
            _balance += amount;
            return WalletBalance;
        }

        /// <summary>
        ///  Method DeductAmount used to Deduct Amount from Wallet of instance of <see cref="UserDetails"/>
        /// </summary>
        /// <param name="amount">amount to deduct</param>
        /// <returns>balance od user</returns>
        public double DeductAmount(double amount)
        {
            _balance -= amount;
            return WalletBalance;
        }

    }
}