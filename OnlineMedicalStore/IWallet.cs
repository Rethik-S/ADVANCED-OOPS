using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public interface IWallet
    {
        //prop
        public double WalletBalance { get; }

        //Methods
        public double WalletRecharge(double amount);
        public double DeductBalance(double amount);

    }
}