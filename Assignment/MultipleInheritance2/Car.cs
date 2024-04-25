using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleInheritance2
{
    public class Car
    {

        public string FuleType { get; set; }
        public int NumberOfSeats { get; set; }
        public string Color { get; set; }
        public double TankCapacity { get; set; }
        public double NumberOfKmDriven { get; set; }

        public Car(string fuleType, int numberOfSeats, string color, double tankCapacity, double numberOfKmDriven)
        {
            FuleType = fuleType;
            NumberOfSeats = numberOfSeats;
            Color = color;
            TankCapacity = tankCapacity;
            NumberOfKmDriven = numberOfKmDriven;
        }

        public double CalculateMilage()
        {
            return NumberOfKmDriven / TankCapacity;
        }
    }
}