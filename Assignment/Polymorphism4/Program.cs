using System;
namespace Polymorphism4;
public class Program
{
    public static void Main(string[] args)
    {
        Syncfusion syncfusion = new Syncfusion("Hiro", "Naga", "male", "B.E", "developer", 10, "Chennai");
        syncfusion.CalculateSalary();
        syncfusion.Display();
    }
}