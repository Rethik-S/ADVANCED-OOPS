using System;
namespace PartialClass2;
public class Program
{
    public static void Main(string[] args)
    {
       Studentinfo studentinfo = new Studentinfo("Hiro","naga",DateTime.Now,Gender.Male,90,90,90);
       studentinfo.Display();
    }
}