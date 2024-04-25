using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance1
{
    public class StudentInfo : PersonalInfo
    {
        //field
        private static int s_StudenetID = 3000;

        //property
        public string StudentID { get; }
        public string Degree { get; set; }
        public string Department { get; set; }
        public string Semester { get; set; }

        //constructor
        public StudentInfo(string personID, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, string degree, string department, string semester) : base(personID, name, fatherName, phone, mail, dob, gender)
        {
            s_StudenetID++;
            StudentID = "SID" + s_StudenetID;

            Degree = degree;
            Department = department;
            Semester = semester;
        }

        //Method
        public void ShowDetails()
        {
            Console.WriteLine($"|{PersonID}|{Name}|{FatherName}|{Phone}|{Mail}|{DOB:dd/MM/yyyy}|{Gender}|{StudentID}|{Degree}|{Department}|{Semester}|");
        }
    }
}