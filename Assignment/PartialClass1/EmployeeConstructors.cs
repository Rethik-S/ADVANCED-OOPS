using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClass1
{
   public partial class EmployeeInfo
    {
        public EmployeeInfo()
        {
            s_employeeID++;
            EmployeeID = "EID"+s_employeeID;
        }
         public EmployeeInfo(string name, string gender, DateTime dOB, string mobile)
        {
            s_employeeID++;
            EmployeeID = "EID"+s_employeeID;
            
            Name = name;
            Gender = gender;
            DOB = dOB;
            Mobile = mobile;
        }
    }
}