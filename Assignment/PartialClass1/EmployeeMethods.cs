using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClass1
{
    public partial class EmployeeInfo
    {
        public void Update(string name, string gender, DateTime dOB, string mobile)
        {
            Name = name;
            Gender = gender;
            DOB = dOB;
            Mobile = mobile;
        }
        public void Display()
        {
            Console.WriteLine($"|{EmployeeID}|{Name}|{Gender}|{DOB:dd/MM/yyyy}|{Mobile}");
        }
    }
}