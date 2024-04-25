using System;
namespace SealedClass4;
public class Program{
    public static void Main(string[] args)
    {
        CircleCalculator circleCalculator = new CircleCalculator();
        circleCalculator.Radius = 10;

        Console.WriteLine($"{circleCalculator.Area()}");

        CylinderCalculator cylinderCalculator = new CylinderCalculator();
        cylinderCalculator.Radius = 10;
        cylinderCalculator.Height=10;

        Console.WriteLine($"{cylinderCalculator.Area()}");
        Console.WriteLine($"{cylinderCalculator.Volume()}");// calculated from area of cylinder circle area cannot be accessed.
        
    }
}