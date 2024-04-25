using System;
namespace Abstraction2;
public class Program
{
    public static void Main(string[] args)
    {
        CSEDepartment cseDepartment = new CSEDepartment();
        cseDepartment.SetBookInfo("patrick","maths","ssr publication","2000");

        EEEdepartment eeeDepartment = new EEEdepartment();
        eeeDepartment.SetBookInfo("stewart","lalaland","holly","2022");

        cseDepartment.DisplayInfo();
        eeeDepartment.DisplayInfo();

    }
}