using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polymorphism5
{
    public class SalaryInfo : EmployeeInfo
    {
        public int NumberOfDaysWorked { get; set; }
        public SalaryInfo(string name, string fatherName, string mobileNumber, string gender, int numberOfDaysWorked) : base(name, fatherName, mobileNumber, gender)
        {
            NumberOfDaysWorked = numberOfDaysWorked;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name}|{FatherName}|{MobileNumber}|{Gender}|{EmployeeID}|{NumberOfDaysWorked}");
        }
    }
}