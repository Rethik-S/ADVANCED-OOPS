using System;
namespace SingleInheritance2;
public class Program
{
    public static void Main(string[] args)
    {

        PersonalInfo person1 = new PersonalInfo("Tony", "Howard", "987654322", "tony@gmail.com", new DateTime(2000, 1, 1), Gender.Male);
        PersonalInfo person2 = new PersonalInfo("Bruce", "Banner", "987652832", "bruce@gmail.com", new DateTime(1998, 2, 3), Gender.Male);
        PersonalInfo person3 = new PersonalInfo("Scott", "James", "987653432", "scott@gmail.com", new DateTime(1994, 2, 5), Gender.Male);

        AccountInfo account1 = new AccountInfo(person1.PersonID, person1.Name, person1.FatherName, person1.Phone, person1.Mail, person1.DOB, person1.Gender, "Mathura", "MA1702", 0);
        AccountInfo account2 = new AccountInfo(person2.PersonID, person2.Name, person2.FatherName, person2.Phone, person2.Mail, person2.DOB, person2.Gender, "Anna nagar", "MA1703", 10);
        AccountInfo account3 = new AccountInfo(person3.PersonID, person3.Name, person3.FatherName, person3.Phone, person3.Mail, person3.DOB, person3.Gender, "Koyembedu", "MA1704", 1000);

        account1.ShowAccountInfo();
        Console.WriteLine($"your balance : {account2.Deposit(20)}");
        Console.WriteLine($"your balance : {account3.WithDraw(30)}");
        Console.WriteLine($"Your balance : {account1.ShowBalance()}");

    }
}