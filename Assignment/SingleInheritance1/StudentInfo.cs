using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInheritance1
{
    public class StudentInfo : PersonalInfo
    {
        //field
        private static int s_registerNumber = 1000;

        //property
        public string RegisterNumber { get; }
        public string Standard { get; set; }
        public string Branch { get; set; }
        public string AcademicYear { get; set; }

        //constructor
        public StudentInfo(string personID, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, string standard, string branch, string academicYear) : base(personID, name, fatherName, phone, mail, dob, gender)
        {
            s_registerNumber++;
            RegisterNumber = "SID" + s_registerNumber;

            Standard = standard;
            Branch = branch;
            AcademicYear = academicYear;
        }

        //Method
        public void ShowStudentInfo()
        {
            Console.WriteLine($"|{PersonID}|{Name}|{FatherName}|{Phone}|{Mail}|{DOB:dd/MM/yyyy}|{Gender}|{RegisterNumber}|{Standard}|{Branch}|{AcademicYear}|");
        }
    }
}