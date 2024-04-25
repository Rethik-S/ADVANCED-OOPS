using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreApplication
{
    public interface IBalance
    {
        public double WalletBalance { get; set; }

        public double WalletRecharge(double amount);
    }
}