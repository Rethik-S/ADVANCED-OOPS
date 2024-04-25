using System;
using System.Collections.Generic;
namespace HybridInheritance1;
public class Program
{
    public static void Main(string[] args)
    {

        PersonalInfo person1 = new PersonalInfo("Tony", "Howard", "987654322", "tony@gmail.com", new DateTime(2000, 1, 1), Gender.Male);
        PersonalInfo person2 = new PersonalInfo("Bruce", "Banner", "987652832", "bruce@gmail.com", new DateTime(1998, 2, 3), Gender.Male);

        Marksheet marksheet1 = new Marksheet(90, DateTime.Now, person1.RegistrationNumber, person1.Name, person1.FatherName, person1.Phone, person1.Mail, person1.DOB, person1.Gender, new List<int> { 90, 90, 80, 70, 60, 90 }, new List<int> { 90, 90, 80, 70, 60, 90 }, new List<int> { 90, 90, 80, 70, 60, 90 }, new List<int> { 90, 90, 80, 70, 60, 90 });
        Marksheet marksheet2 = new Marksheet(90, DateTime.Now, person2.RegistrationNumber, person2.Name, person2.FatherName, person2.Phone, person2.Mail, person2.DOB, person2.Gender, new List<int> { 90, 90, 80, 70, 60, 90 }, new List<int> { 90, 90, 80, 70, 60, 90 }, new List<int> { 90, 90, 80, 70, 60, 90 }, new List<int> { 90, 90, 80, 70, 60, 90 });

        marksheet1.CalculateUG();
        marksheet2.CalculateUG();
        Console.WriteLine($"{marksheet1.ShowUGMarkSheet()}");
        Console.WriteLine($"{marksheet2.ShowUGMarkSheet()}");

    }
}