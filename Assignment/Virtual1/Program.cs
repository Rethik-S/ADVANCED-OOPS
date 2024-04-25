using System;
namespace Virtual1;

public class Program
{
    public static void Main(string[] args)
    {
        AreaCalculator areaCalculator = new AreaCalculator();
        areaCalculator.Radius = 5;
        areaCalculator.Display();


        VolumeCalculator volumeCalculator = new VolumeCalculator();
        volumeCalculator.Radius = 5;
        volumeCalculator.Height = 10;
        volumeCalculator.Display();


    }
}