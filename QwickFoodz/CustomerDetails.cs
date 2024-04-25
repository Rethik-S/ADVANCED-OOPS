using System;

namespace QwickFoodz
{
    public class CustomerDetails : PersonalDetails, IBalance
    {
        //field
        private static int s_customerID = 1000;
        private double _balance;



        //Auto property
        public string CustomerID { get; }//read only property
        public double WalletBalance { get { return _balance; } }


        //constructor
        public CustomerDetails(double balance, string name, string fatherName, Gender gender, string mobile, DateTime dOB, string mailID, string location) : base(name, fatherName, gender, mobile, dOB, mailID, location)
        {
            //Auto Incrementaataion
            s_customerID++;
            CustomerID = "CID" + s_customerID;

            _balance = balance;
        }

        public CustomerDetails(string user)
        {
            string[] values = user.Split(",");
            s_customerID = int.Parse(values[0].Remove(0, 3));
            CustomerID = values[0];
            _balance = double.Parse(values[1]);
            Name = values[2];
            FatherName = values[3];
            Gender = Enum.Parse<Gender>(values[4]);
            Mobile = values[5];
            DOB = DateTime.ParseExact(values[6], "dd/MM/yyyy", null);
            MailID = values[7];
            Location = values[8];
        }

        //Methods
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