using System;
namespace Polymorphism7;
public class Program
{
    public static void Main(string[] args)
    {
        Attendance month1 = new Attendance(30, 2, 1);
        Attendance month2 = new Attendance(30, 2, 1);
        Attendance month3 = new Attendance(30, 2, 1);

        int totalWorkingDays = month1.TotalWorkingDaysInMonth + month2.TotalWorkingDaysInMonth + month3.TotalWorkingDaysInMonth;
        int numberOfLeavesTaken = month1.NumberOfLeavesTaken + month2.NumberOfLeavesTaken + month3.NumberOfLeavesTaken;
        int NumberOfPermissionsTaken = month1.NumberOfPermissionsTaken + month2.NumberOfPermissionsTaken + month3.NumberOfPermissionsTaken;

        double Salary = (totalWorkingDays - numberOfLeavesTaken - NumberOfPermissionsTaken) * 500;
        Console.WriteLine(Salary);
        
    }

}
