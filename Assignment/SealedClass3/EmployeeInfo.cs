using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClass3
{
    public class EmployeeInfo : FamilyInfo
    {
        private static int s_employeeID = 1000;



        public string EmployeeID { get; }
        public DateTime DateOfJoining { get; set; }


        public EmployeeInfo(DateTime dateOfJoining, string name, string fatherName, string mobile, string mail, string gender, string motherName, string noOfSiblings, string nativePlace) : base(name, fatherName, mobile, mail, gender, motherName, noOfSiblings, nativePlace)
        {
            s_employeeID++;
            EmployeeID = "EID" + s_employeeID;
            DateOfJoining = dateOfJoining;
        }

        //Cannot override because it is sealed

        // public override void Update(string name, string fatherName, string mobile, string mail, string gender)
        // {

        // } 

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Name}|{FatherName}|{Mobile}|{Mail}|{Gender}|{MotherName}|{NoOfSiblings}|{NativePlace}|{EmployeeID}|{DateOfJoining:dd/MM/yyyy}");
            
        }

    }
}