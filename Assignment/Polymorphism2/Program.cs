using System;
namespace Polymorphism2;

public class Program
{
    public static void Main(string[] args)
    {
        Square(2);
        Square(2.0f);
        Square(2.0);
        Square(223432L);
    }

    public static void Square(int a)
    {
        Console.WriteLine($"{a*a}");
        
    }
    public static void Square(float a)
    {
        Console.WriteLine($"{a*a}");
        
    }
    public static void Square(double a)
    {
        Console.WriteLine($"{a*a}");
        
    }
    public static void Square(long a)
    {
        Console.WriteLine($"{a*a}");
        
    }
}