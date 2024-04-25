using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritance1
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

        public StudentInfo():base()
        {
            s_registerNumber++;
            RegisterNumber = "SID" + s_registerNumber;
        }


        public StudentInfo(string personID, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, string standard, string branch, string academicYear) : base(personID, name, fatherName, phone, mail, dob, gender)
        {
            s_registerNumber++;
            RegisterNumber = "SID" + s_registerNumber;

            Standard = standard;
            Branch = branch;
            AcademicYear = academicYear;
        }
        public StudentInfo(string registerNumber,string personID, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, string standard, string branch, string academicYear) : base(personID, name, fatherName, phone, mail, dob, gender)
        {
            RegisterNumber = registerNumber;
            Standard = standard;
            Branch = branch;
            AcademicYear = academicYear;
        }

        //Method
        public void ShowInfo()
        {
            Console.WriteLine($"|{PersonID}|{Name}|{FatherName}|{Phone}|{Mail}|{DOB:dd/MM/yyyy}|{Gender}|{RegisterNumber}|{Standard}|{Branch}|{AcademicYear}|");
        }

        public void GetStudentInfo(string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, string standard, string branch, string academicYear)
        {
            Name = name;
            FatherName = fatherName;
            Phone = phone;
            Mail = mail;
            DOB = dob;
            Gender = gender;
            Standard = standard;
            Branch = branch;
            AcademicYear = academicYear;
        }
    }
}