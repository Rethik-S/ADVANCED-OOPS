using System;
namespace Interface2;
public class Program
{
    public static void Main(string[] args)
    {
        StudentInfo studentInfo1 =new StudentInfo("siva","kumar","89948238");
        StudentInfo studentInfo2 =new StudentInfo("surya","ramesh","89948238");

        EmployeeInfo employee1 = new EmployeeInfo("ramesh","suresh");
        EmployeeInfo employee2 = new EmployeeInfo("rakesh","sathish");

        studentInfo1.Display();
        studentInfo2.Display();
        
        employee1.Display();
        employee2.Display();

    }
}