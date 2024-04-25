using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtual1
{
    public class AreaCalculator
    {
        public double Radius { get; set; }

        public virtual double Calculate()
        {
            double area = 3.14*Radius*Radius;
            return area;
        }
        public virtual void Display()
        {
            Console.WriteLine($"Area: {Calculate()}");
            
        }
    }
}