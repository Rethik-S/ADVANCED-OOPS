using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridInheritance2
{
    public interface ICalculate
    {
        public double Deposit(int amount);
        public double Withdraw(int amount);
        public double BalanceCheck();
    }
}