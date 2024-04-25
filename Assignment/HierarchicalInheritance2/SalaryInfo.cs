using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance2
{
    public class SalaryInfo
    {
        public SalaryInfo(double basicSalary, DateTime month)
        {
            BasicSalary = basicSalary;
            Month = month;
        }

        public double BasicSalary { get; set; }
        public DateTime Month { get; set; }

    }
}