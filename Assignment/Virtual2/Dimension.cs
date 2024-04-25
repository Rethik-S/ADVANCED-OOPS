using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Virtual2
{
    public class Dimension
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Area { get; set; }

        public virtual double Calculate()
        {
            Area = Value1*Value2;
            return Area;
        }

        public virtual void DisplayArea()
        {
            Console.WriteLine($"Area: {Calculate()}");
        }
    }
}