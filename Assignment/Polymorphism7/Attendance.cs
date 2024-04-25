using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polymorphism7
{
    public class Attendance
    {

        public int TotalWorkingDaysInMonth { get; set; }
        public int NumberOfLeavesTaken { get; set; }
        public int NumberOfPermissionsTaken { get; set; }
        public Attendance(int totalWorkingDaysInMonth, int numberOfLeavesTaken, int numberOfPermissionsTaken)
        {
            TotalWorkingDaysInMonth = totalWorkingDaysInMonth;
            NumberOfLeavesTaken = numberOfLeavesTaken;
            NumberOfPermissionsTaken = numberOfPermissionsTaken;
        }
    }
}