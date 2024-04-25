using System;
namespace MultipleInheritance1;
public class Program
{
    public static void Main(string[] args)
    {
        RegisterPerson registerPerson = new RegisterPerson("hiro", "Male", new DateTime(2001, 2, 23), "3403444", "9374343733", MaritalDetails.Single, "Nobita", "Sizuka", "No : 07, Japan Street, Japan", 1, DateTime.Now);
        RegisterPerson registerPerson2 = new RegisterPerson("shiro", "Female", new DateTime(2001, 2, 23), "3403444", "9345443743", MaritalDetails.Single, "Nobita", "Sizuka", "No : 07, Japan Street, Japan", 1, DateTime.Now);
        registerPerson.ShowInfo();
        registerPerson2.ShowInfo();
    }
}