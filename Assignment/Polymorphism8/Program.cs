using System;
namespace Polymorphism8;
public class Program{
    public static void Main(string[] args)
    {
        Calculator sem1 = new Calculator(90,90,90,90,90,90);
        Calculator sem2 = new Calculator(90,90,70,90,90,80);
        Calculator sem3 = new Calculator(90,70,90,80,90,80);
        Calculator sem4 = new Calculator(80,90,90,80,80,90);

        Calculator calculator1 = sem1+sem2+sem3+sem4;
        Calculator calculator2 = Calculator.Add(sem1,sem2,sem3,sem4);

        int total1 = calculator1.Subject1+calculator1.Subject2+calculator1.Subject3+calculator1.Subject4+calculator1.Subject5+calculator1.Subject6;
        int total2 = calculator2.Subject1+calculator2.Subject2+calculator2.Subject3+calculator2.Subject4+calculator2.Subject5+calculator2.Subject6;
       
       Console.WriteLine($"method total :{total1}");
       Console.WriteLine($"operator total :{total2}");
       Console.WriteLine($"method percentage :{total1/6}");
       Console.WriteLine($"operator percentage :{total2/6}");
       TimeSpan span = DateTime.Now-new DateTime(2024,4,19);
       Console.WriteLine($"{span.Days}");
       System.Console.WriteLine(DateTime.Compare(DateTime.Now,new DateTime(2024,4,16)));
       
       
    }
}