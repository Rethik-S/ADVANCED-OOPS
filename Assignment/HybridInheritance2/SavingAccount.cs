using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridInheritance2
{
    public class SavingAccount : IDInfo, ICalculate, IBankInfo
    {

        private static int s_accountNumber = 6000000;
        private double _balance = 0;

        

        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public double Balance { get { return _balance; } set { _balance = value; } }

        public string BankName { get; set; }
        public string IFSC { get; set; }
        public string Branch { get; set; }

        

        public SavingAccount(string name, string gender, DateTime dOB, string phone, string mobile,string voterID, string aadharID, string pan,string accountType, double balance, string bankName, string iFSC, string branch):base(name,gender,dOB,phone,mobile,voterID,aadharID,pan)
        {
            s_accountNumber++;
            AccountNumber="SAC"+s_accountNumber;

            AccountType = accountType;
            Balance = balance;
            BankName = bankName;
            IFSC = iFSC;
            Branch = branch;
        }



        public double Deposit(int amount)
        {
            Balance += amount;
            return Balance;
        }
        public double Withdraw(int amount)
        {
            Balance -= amount;
            return Balance;
        }
        public double BalanceCheck()
        {
            return Balance;
        }


    }
}