using System;
namespace Polymorphism5;
public class Program{
    public static void Main(string[] args)
    {
        EmployeeInfo employeeInfo = new EmployeeInfo("Hiro","Naga","348838449","Male");
        employeeInfo.Display();
        SalaryInfo salaryInfo = new SalaryInfo(employeeInfo.Name,employeeInfo.FatherName,employeeInfo.MobileNumber,employeeInfo.Gender,10);
        salaryInfo.Display();
        
    }
}