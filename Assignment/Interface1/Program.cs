using System;
using System.Collections.Generic;
namespace Interface1;
public class Program
{
    public static void Main(string[] args)
    {
        List<IAnimal> animals = new List<IAnimal>();

        Dog dog1 = new Dog("pomerian","domestic","pedigree");
        Dog dog2 = new Dog("bull dog","domestic","meat");

        Duck duck1 = new Duck("x","lake","fish");
        Duck duck2 = new Duck("y","river","fish");

        dog1.DisplayInfo();
        dog2.DisplayName();

        duck1.DisplayName();
        duck2.DisplayInfo();

        animals.AddRange(new List<IAnimal>{dog1,dog2,duck1,duck2});
    }
}