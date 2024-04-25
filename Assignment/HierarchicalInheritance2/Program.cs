using System;
namespace HierarchicalInheritance2;
public class Program
{
    public static void Main(string[] args)
    {
       PermanentEmployee permanent1 = new PermanentEmployee(1000,DateTime.Now,"Developer");
       PermanentEmployee permanent2 = new PermanentEmployee(500,DateTime.Now,"Network Engineer");

       TemporaryEmployee temporary1 = new TemporaryEmployee(500,DateTime.Now,"developer");
       TemporaryEmployee temporary2 = new TemporaryEmployee(400,DateTime.Now,"tester");

       permanent1.CalculateTotalSalary();
       permanent2.CalculateTotalSalary();

       permanent1.ShowSalary();
       permanent2.ShowSalary();

       temporary1.CalculateTotalSalary();
       temporary2.CalculateTotalSalary();
       
       temporary1.ShowSalary();
       temporary2.ShowSalary();

    }
}