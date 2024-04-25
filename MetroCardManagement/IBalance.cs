using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public interface IBalance
    {
        //auto property
        public double Balance { get; set; }


        //Methods
        public double WalletRecharge(double amount);
        public double DeductBalance(double amount);

    }
}