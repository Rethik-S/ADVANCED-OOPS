using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abstraction3
{
    public abstract class Car
    {
        protected int _wheels=4;
        protected int _doors=4;

        

        public string EngineType { get; set; }
        public int Seats { get; set; }
        public double Price { get; set; }
        public string CarType { get; set; }

        public void ShowWheels()
        {
            Console.WriteLine($"{_wheels}");
            
        }
        public void ShowDoors()
        {
            Console.WriteLine($"{_doors}");
        }

        public abstract void GetEngineType();
        public abstract void GetNoOfSeats();
        public abstract void GetPrice();
        public abstract void GetCarType();
        public abstract void DisplayCarDetail();
    }
}