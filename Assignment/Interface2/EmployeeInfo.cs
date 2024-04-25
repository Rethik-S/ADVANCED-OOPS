using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface2
{
    public class EmployeeInfo:IDisplayInfo
    {
        private static int s_employeeID=100;
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public EmployeeInfo(string name, string fatherName)
        {
            s_employeeID++;
            EmployeeID="EID"+s_employeeID;

            Name = name;
            FatherName = fatherName;
        }

        public void Display()
        {
            Console.WriteLine($"{EmployeeID}|{Name}|{FatherName}");
            
        }
    }
}