using System;
using System.Collections.Generic;
namespace MultilevelInheritance2;
public class Program
{
    public static void Main(string[] args)
    {
        // DepartmentDetails departmentDetails = new DepartmentDetails("CSE","B.E");
        // RackInfo rackInfo = new RackInfo(departmentDetails.DepartmentID,departmentDetails.DepartmentName,departmentDetails.Degree,1,1);
        // BookInfo book = new BookInfo(rackInfo.RackID,rackInfo.DepartmentID,rackInfo.DepartmentName,rackInfo.Degree,rackInfo.RackNumber,rackInfo.ColumnNumber,"Wings of fire","abdul kalam",200);
        List<BookInfo> bookInfosList = new List<BookInfo>(); 

        DepartmentDetails departmentDetails1 = new DepartmentDetails("CSE", "B.E");
        DepartmentDetails departmentDetails2 = new DepartmentDetails("EEE", "B.E");

        RackInfo rackInfo1 = new RackInfo(departmentDetails1.DepartmentName, departmentDetails1.Degree, 1, 1);
        RackInfo rackInfo2 = new RackInfo(departmentDetails1.DepartmentName, departmentDetails1.Degree, 2, 3);
        RackInfo rackInfo3 = new RackInfo(departmentDetails2.DepartmentName, departmentDetails2.Degree, 2, 5);
        
        BookInfo book1 = new BookInfo(rackInfo1.DepartmentName, rackInfo1.Degree, rackInfo1.RackNumber, rackInfo1.ColumnNumber, "Wings of fire", "abdul kalam", 200);
        BookInfo book2= new BookInfo(rackInfo2.DepartmentName, rackInfo2.Degree, rackInfo2.RackNumber, rackInfo2.ColumnNumber, "x", "abdul kalam", 500);
        BookInfo book3 = new BookInfo(rackInfo3.DepartmentName, rackInfo3.Degree, rackInfo3.RackNumber, rackInfo3.ColumnNumber, "Y", "kamal", 300);

        bookInfosList.AddRange(new List<BookInfo>{book1,book2,book3});
        book1.DisplayInfo();
        book2.DisplayInfo();
        book3.DisplayInfo();

    }
}