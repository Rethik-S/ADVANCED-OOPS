using System;
namespace SealedClass3;
public class Program{
    public static void Main(string[] args)
    {
        EmployeeInfo employeeInfo = new EmployeeInfo(DateTime.Now,"Hiro","naga","9349332","hiro@gmail","male","sakura","3","fiji");
        employeeInfo.DisplayInfo();

        //getting the update method from FamilyInfo class through Inheritance
        employeeInfo.Update("Hiroshi","Naga","893832","hiro203@mail.com","male");

        employeeInfo.DisplayInfo();
    }
}