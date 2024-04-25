using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClass1
{
    public class EmployeeProps
    {
        
    }public partial class EmployeeInfo
    {
        private static int s_employeeID=1000;

       

        public string EmployeeID { get; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Mobile { get; set; }
    }
}