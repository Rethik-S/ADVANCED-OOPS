using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtual2
{
    public class Rectangle:Dimension
    {
        public double Length { get; set; }
        public double height { get; set; }

        public override double Calculate()
        {
            Area = Length*height;
            return Area;
        }

        public override void DisplayArea()
        {
            Console.WriteLine($"Rectangle Area: {Calculate()}");
        }
    }
}