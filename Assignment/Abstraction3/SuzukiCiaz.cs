using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abstraction3
{
    public class SuzukiCiaz:Car
    {
        public SuzukiCiaz(string engineType, int seats, double price, string carType)
        {
            EngineType = engineType;
            Seats = seats;
            Price = price;
            CarType = carType;
        }

        public override void GetEngineType()
        {
            Console.WriteLine($"{EngineType}");

        }
        public override void GetNoOfSeats()
        {
            Console.WriteLine($"{Seats}");
        }
        public override void GetPrice()
        {
            Console.WriteLine($"{Price}");

        }
        public override void GetCarType()
        {
            Console.WriteLine($"{CarType}");
            
        }
        public override void DisplayCarDetail()
        {
            Console.WriteLine($"{_wheels}|{_doors}|{EngineType}|{Seats}|{Price}|{CarType}|");
            
        }
    }
}