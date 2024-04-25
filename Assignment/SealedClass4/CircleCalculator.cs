using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClass4
{
    public class CircleCalculator : Calculator
    {
        public double Radius { get; set; }
        public sealed override double Area()//sealed methods cannot be override by class which inherit Circle Calculator
        {
            double area = 3.14 * Radius * Radius;
            return area;
        }

        public override double Volume()
        {
            return 0;
        }

    }
}