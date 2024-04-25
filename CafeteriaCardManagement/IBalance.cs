using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public interface IBalance
    {
        //Auto property
        public double WalletBalance { get; }

        //Methods
        public double WalletRecharge(double amount);
        public double DeductAmount(double amount);
    }
}