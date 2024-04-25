using System;
namespace PartialClass1;
public class Program
{
    public static void Main(string[] args)
    {
        EmployeeInfo employeeInfo1 = new EmployeeInfo();
        employeeInfo1.Update("Suresh","male",new DateTime(2002,4,3),"98348238");
        employeeInfo1.Display();

        EmployeeInfo employeeInfo2 = new EmployeeInfo("ramesh","male",new DateTime(2000,4,23),"983248238");
        employeeInfo2.Display();


    }
}