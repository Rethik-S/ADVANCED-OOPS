using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface2
{
    public class StudentInfo:IDisplayInfo
    {
        private static int s_studentID=2000;
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Mobile { get; set; }
        public StudentInfo(string name, string fatherName, string mobile)
        {
            s_studentID++;
            StudentID="SID"+s_studentID;

            Name = name;
            FatherName = fatherName;
            Mobile = mobile;
        }

        public void Display()
        {
            Console.WriteLine($"{StudentID}|{Name}|{FatherName}|{Mobile}");
            
        }
    }
}