using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abstraction4
{
    public abstract class Dress
    {
        protected double _totalPrice=0;
        public abstract string DressType { get; set; }
        public abstract string DressName { get; set; }
        public abstract double Price { get; set; }
        public abstract double TotalPrice { get; set; }

        public abstract void GetDressInfo(string dressType, string dressName, double price);
        public abstract void DisplayInfo();
    }
}