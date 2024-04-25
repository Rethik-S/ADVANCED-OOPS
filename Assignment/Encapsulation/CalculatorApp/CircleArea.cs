using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathsLib;
namespace CalculatorApp
{
    public class CircleArea : Maths
    {
        //can be accessed in child class of CircleArea
        protected double _radius;

        
        //can be accesed from anywhere
        public double Radius { get { return _radius; } set { _radius = value; } }
        
        //can be accesed in this CalculatorApp namespace.
        internal double Area { get; set; }


        public double CalculateCircleArea()
        {
            Area = PI * Radius * Radius;
            return Area;
        }



    }
}