using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritance2
{
    public class RackInfo : DepartmentDetails
    {
        // private static int s_rackID = 100;
        // public string RackID { get; }


        public int RackNumber { get; set; }
        public int ColumnNumber { get; set; }



        public RackInfo(string departmentName, string degree, int rackNumber, int columnNumber) : base(departmentName, degree)
        {
            RackNumber = rackNumber;
            ColumnNumber = columnNumber;
        }

        // public RackInfo(string departmentID, string departmentName, string degree, int rackNumber, int columnNumber) : base(departmentID, departmentName, degree)
        // {
        //     s_rackID++;
        //     RackID = "RID" + s_rackID;

        //     RackNumber = rackNumber;
        //     ColumnNumber = columnNumber;
        // }
        // public RackInfo(string rackID, string departmentID, string departmentName, string degree, int rackNumber, int columnNumber) : base(departmentID, departmentName, degree)
        // {
        //     RackID = rackID;
        //     RackNumber = rackNumber;
        //     ColumnNumber = columnNumber;
        // }
    }
}