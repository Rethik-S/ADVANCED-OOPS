using System;
namespace MultipleInheritance2;
public class Program
{
    public static void Main(string[] args)
    {
        ShiftDezire shiftDezire1 = new ShiftDezire("Petrol", 4, "red", 40, 200, "ksia39320", "kjeddw987s8d799", "SUZUKI", "Shift Dezire");
        ShiftDezire shiftDezire2 = new ShiftDezire("Petrol", 4, "blue", 40, 100, "ksds4320", "adjasw87s8d799", "SUZUKI", "Shift Dezire");

        Eco eco1 = new Eco("Diesel", 5, "orange", 40, 140, "jkas3420", "oscsdasw87s8d799", "Renault", "Eco");
        Eco eco2 = new Eco("Diesel", 4, "yellow", 40, 193, "ajss4320", "kjjkds988d9s", "Renault", "Eco");

        shiftDezire1.ShowDetails();
        Console.WriteLine($"Milage: {shiftDezire1.CalculateMilage()}");

        shiftDezire2.ShowDetails();
        Console.WriteLine($"Milage: {shiftDezire2.CalculateMilage()}");

        eco1.ShowDetails();
        Console.WriteLine($"Milage: {eco1.CalculateMilage()}");

        eco2.ShowDetails();
        Console.WriteLine($"Milage: {eco2.CalculateMilage()}");

    }
}