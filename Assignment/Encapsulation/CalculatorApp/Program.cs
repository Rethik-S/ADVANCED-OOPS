using System;
namespace CalculatorApp;

public class Program{
    public static void Main(string[] args)
    {
        CircleArea circleArea =  new CircleArea();
        circleArea.Radius = 5;

        Console.WriteLine($"circle Area: {circleArea.CalculateCircleArea()}");
        Console.WriteLine($"Radius: {circleArea.Radius}");
        Console.WriteLine($"Area: {circleArea.Area}");

        CylinderVolume cylinderVolume = new CylinderVolume();
        cylinderVolume.Radius = 10;
        cylinderVolume.Height = 15;

        Console.WriteLine($"cylinder Volume: {cylinderVolume.CalculateVolume()}");
        Console.WriteLine($"circle Area: {cylinderVolume.CalculateCircleArea()}");
        Console.WriteLine($"Radius: {cylinderVolume.Radius}");
        Console.WriteLine($"Height: {cylinderVolume.Height}");
        Console.WriteLine($"Volume: {cylinderVolume.Volume}");

        
    }
}