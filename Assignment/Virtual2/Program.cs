using System;
namespace Virtual2;

public class Program{
    public static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle();
        rectangle.Length=10;
        rectangle.height=5;
        rectangle.DisplayArea();

        Sphere sphere = new Sphere();
        sphere.Radius = 10;
        sphere.DisplayArea();


    }
}