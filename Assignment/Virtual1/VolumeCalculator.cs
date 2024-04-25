using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtual1
{
    public class VolumeCalculator:AreaCalculator
    {
        public double Height { get; set; }

        public override double Calculate()
        {
            double area = 3.14*Radius*Radius*Height;
            return area;
        }
        public override void Display()
        {
            Console.WriteLine($"Volume: {Calculate()}");
            
        }
    }
}