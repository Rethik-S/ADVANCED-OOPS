using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance2
{
    public class TemporaryEmployee : SalaryInfo
    {
        private static int s_employeeID = 20000;


        public string EmployeeID { get; }

        public string EmployeeType { get; set; }
        public double DA { get { return BasicSalary * 0.15; } }
        public double HRA { get { return BasicSalary * 0.13; } }
        private double Total { get; set; }



        public TemporaryEmployee(double basicSalary, DateTime month, string employeeType) : base(basicSalary, month)
        {
            s_employeeID++;
            EmployeeID = "TEID" + s_employeeID;
            EmployeeType = employeeType;
        }

        public void CalculateTotalSalary()
        {
            Total = (BasicSalary + DA + HRA) * DateTime.DaysInMonth(Month.Year, Month.Month);
        }

        public void ShowSalary()
        {
            Console.WriteLine($"{Total}");

        }

    }
}