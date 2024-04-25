using System;
namespace Polymorphism6;
public class Program
{
    public static void Main(string[] args)
    {
        Bank sbi = new SBI();
        Bank icici = new SBI();
        Bank hdfc = new SBI();
        Bank idbc = new SBI();
        Console.WriteLine($"{sbi.GetIntresetInfo()}%");
        Console.WriteLine($"{icici.GetIntresetInfo()}%");
        Console.WriteLine($"{hdfc.GetIntresetInfo()}%");
        Console.WriteLine($"{idbc.GetIntresetInfo()}%");
        
    }
}