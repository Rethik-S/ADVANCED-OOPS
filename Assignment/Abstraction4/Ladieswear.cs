using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abstraction4
{
    public class Ladieswear : Dress
    {
        public override string DressType { get; set; }
        public override string DressName { get; set; }
        public override double Price { get; set; }
        
        //20% discount
        public override double TotalPrice { get { return _totalPrice += Price-(Price*0.2); } set { _totalPrice = value; } }



        public override void GetDressInfo(string dressType, string dressName, double price)
        {
            DressType = dressType;
            DressName = dressName;
            Price = price;
        }
        public override void DisplayInfo()
        {

            Console.WriteLine($"{DressType}|{DressName}|{Price}|{TotalPrice}");

        }
    }
}