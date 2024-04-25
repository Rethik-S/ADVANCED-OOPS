using System;
namespace Abstraction3;
public class Program
{
    public static void Main(string[] args)
    {
        MaruthiSwift maruthiSwift = new MaruthiSwift("Petrol", 2, 800000, "hatchback");
        maruthiSwift.GetEngineType();
        maruthiSwift.GetNoOfSeats();
        maruthiSwift.GetPrice();
        maruthiSwift.GetCarType();
        maruthiSwift.DisplayCarDetail();

        SuzukiCiaz suzukiCiaz = new SuzukiCiaz("diesel",6,1200000,"SUV");
        suzukiCiaz.GetEngineType();
        suzukiCiaz.GetNoOfSeats();
        suzukiCiaz.GetPrice();
        suzukiCiaz.GetCarType();
        suzukiCiaz.DisplayCarDetail();

    }
}