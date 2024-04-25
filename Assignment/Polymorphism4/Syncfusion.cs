using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polymorphism4
{
    public class Syncfusion : FreeLancer
    {
        private static int s_employeeID = 1000;
        public string EmployeeID { get; set; }
        public string WorkLocation { get; set; }
        public Syncfusion(string name, string fatherName, string gender, string qualification, string role, int noOfWorkingDays, string workLocation) : base(name, fatherName, gender, qualification, role, noOfWorkingDays)
        {
            s_employeeID++;
            EmployeeID = "EID" + s_employeeID;

            WorkLocation = workLocation;
        }

        public override void CalculateSalary()
        {
            SalaryAmount = NoOfWorkingDays * 500;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name}|{FatherName}|{Gender}|{Qualification}|{Role}|{SalaryAmount}|{NoOfWorkingDays}|{WorkLocation}");

        }
    }
}