using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polymorphism5
{
    public class EmployeeInfo:PersonalInfo
    {
        private static int s_employeeID = 1000;


        public string EmployeeID { get; }

        public EmployeeInfo(string name, string fatherName, string mobileNumber, string gender) : base(name, fatherName, mobileNumber, gender)
        {
            s_employeeID++;
            EmployeeID="EID"+s_employeeID;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name}|{FatherName}|{MobileNumber}|{Gender}|{EmployeeID}");
            
        }
    }
}