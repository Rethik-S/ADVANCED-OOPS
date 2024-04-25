using System;
namespace Abstraction1;
public class Program
{
    public static void Main(string[] args)
    {
        Cylinders cylinder = new Cylinders();

        cylinder.Radius = 2;
        cylinder.Height = 5;
        cylinder.Width = 4;

        cylinder.CalculateArea();
        cylinder.CalculateVolume();

        Cubes cube = new Cubes();

        cube.a = 3;

        cube.CalculateArea();
        cube.CalculateVolume();
    }
}