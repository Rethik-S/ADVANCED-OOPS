using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class CylinderVolume : CircleArea
    {
        //can only accessed in this class
        private double _height;

        //can be accesed from anywhere
        public double Height { get { return _height; } set { _height = value; } }

        //can be accesed in this CalculatorApp namespace.
        internal double Volume { get; set; }

        public double CalculateVolume()
        {
            Volume = CalculateCircleArea() * Height;
            return Volume;
        }

    }
}