using System;
namespace Abstraction4;
public class Program
{
    public static void Main(string[] args)
    {
        Ladieswear ladieswear = new Ladieswear();
        ladieswear.GetDressInfo("saree","saree",1000);

        Menswear menswear = new Menswear();
        menswear.GetDressInfo("shirt","polo",1000);

        menswear.DisplayInfo();
        ladieswear.DisplayInfo();
    }
}