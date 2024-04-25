using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace HierarchicalInheritance2
{
    public class PermanentEmployee : SalaryInfo
    {
        private static int s_employeeID = 10000;


        public string EmployeeID { get; }

        public string EmployeeType { get; set; }
        public double DA { get { return BasicSalary * 0.2; } }
        public double HRA { get { return BasicSalary * 0.18; } }
        public double PF { get { return BasicSalary * 0.01; } }
         private double Total { get; set; }


        public PermanentEmployee(double basicSalary, DateTime month, string employeeType) : base(basicSalary, month)
        {
            s_employeeID++;
            EmployeeID = "PEID" + s_employeeID;
            EmployeeType = employeeType;
        }

        public void CalculateTotalSalary()
        {
            Total = (BasicSalary + DA + HRA-PF) * DateTime.DaysInMonth(Month.Year, Month.Month);
        }
        public void ShowSalary()
        {
            Console.WriteLine($"{Total}");

        }
    }
}