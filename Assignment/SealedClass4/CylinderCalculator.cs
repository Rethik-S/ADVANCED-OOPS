using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClass4
{
    public class CylinderCalculator : Calculator
    {
        public double Radius { get; set; }
        public double Height { get; set; }
        public override double Area()
        {
            double area = 2 * 3.14 * Radius * (Radius + Height);
            return area;
        }

        public override double Volume()
        {
            return Area() * Height;//cannot get area from circle calculator calculator class is inherited not circlr calculator
        }
    }
}