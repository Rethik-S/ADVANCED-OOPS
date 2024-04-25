using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInheritance2
{
    public class AccountInfo : PersonalInfo
    {

        private static int s_accountNumber = 600000;
        private double _balance;


        public string AccountNumber { get; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public double Balance { get { return _balance; } set { _balance = value; } }

        public AccountInfo(string personID, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, string branchName, string iFSCCode, double balance) : base(personID, name, fatherName, phone, mail, dob, gender)
        {
            s_accountNumber++;
            AccountNumber = "AC" + s_accountNumber;

            BranchName = branchName;
            IFSCCode = iFSCCode;
            Balance = balance;
        }

        //Methods
        public void ShowAccountInfo()
        {
            Console.WriteLine($"|{PersonID}|{Name}|{FatherName}|{Phone}|{Mail}|{DOB:dd/MM/yyyy}|{Gender}|{AccountNumber}|{BranchName}|{IFSCCode}|");
        }

        public double Deposit(double amount)
        {
            Balance+=amount;
            return Balance;
        }
        public double WithDraw(double amount)
        {
            if(amount>Balance)
            {
                return Balance;
            }
            Balance-=amount;
            return Balance;
        }
        public double ShowBalance()
        {
            return Balance;
        }
    }
}