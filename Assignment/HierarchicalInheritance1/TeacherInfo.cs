using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance1
{
    public class TeacherInfo : PersonalInfo
    {
        private static int s_teacherID = 2000;


        public string TeacherID { get; }
        public string Department { get; set; }
        public string SubjectTeaching { get; set; }
        public string Qualification { get; set; }
        public int YearOfExperience { get; set; }
        public DateTime DateOfJoining { get; set; }

        public TeacherInfo(string personID, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, string department, string subjectTeaching, string qualification, int yearOfExperience, DateTime dateOfJoining) : base(personID, name, fatherName, phone, mail, dob, gender)
        {
            s_teacherID++;
            TeacherID = "TID" + s_teacherID;

            Department = department;
            SubjectTeaching = subjectTeaching;
            Qualification = qualification;
            YearOfExperience = yearOfExperience;
            DateOfJoining = dateOfJoining;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"|{PersonID}|{Name}|{FatherName}|{Phone}|{Mail}|{DOB:dd/MM/yyyy}|{Gender}|{TeacherID}|{Department}|{SubjectTeaching}|{Qualification}|{YearOfExperience}|{DateOfJoining:dd/MM/yyyy}");

        }
    }
}