using System;
namespace Polymorphism1;
public class Program
{
    public static void Main(string[] args)
    {
        Square(10);
        method(1, 2);
        method(1, 2, 3);
        method(1, "hello");
        method(1, 2.0, "adsdsai");
    }

    public static void Square(int a)
    {
        Console.WriteLine($"{a * a}");
    }

    public static void method(int a, int b)
    {
        Console.WriteLine($"{a + b}");
    }
    public static void method(int a, int b, int c)
    {
        Console.WriteLine($"{a + b + c}");
    }
    public static void method(int a, string b)
    {
        Console.WriteLine($"{a}{b}");
    }
    public static void method(int a, double b, string c)
    {
        Console.WriteLine($"{a}{b}{c}");
    }

}