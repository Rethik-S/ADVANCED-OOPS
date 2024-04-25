using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abstraction1
{
    public class Cubes : Shape
    {
        public override double Area { get { return _area; } set { _area = value; } }
        public override double Volume { get { return _volume; } set { _volume = value; } }

        public override void CalculateArea()
        {
            Area = 6 * a * a;
            Console.WriteLine($"Area : {Area}");

        }
        public override void CalculateVolume()
        {
            Volume = a * a * a;
            Console.WriteLine($"Volume : {Volume}");
        }
    }
}