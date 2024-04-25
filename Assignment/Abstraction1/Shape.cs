using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abstraction1
{
    public abstract class Shape
    {
        protected double _area;//normal field
        protected double _volume;//normal field

        public abstract double Area { get; set; }
        public abstract double Volume { get; set; }

        public double a { get; set; }
        public double Radius { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public abstract void CalculateArea();
        public abstract void CalculateVolume();
    }
}