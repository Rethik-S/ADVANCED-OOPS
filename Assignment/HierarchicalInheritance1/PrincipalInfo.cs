using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance1
{
    public class PrincipalInfo : PersonalInfo
    {
        private static int s_principalID = 4000;

        public string PrincipalID { get; }
        public string Qualification { get; set; }
        public int YearOfExperience { get; set; }
        public DateTime DateOfJoining { get; set; }

        public PrincipalInfo(string personID, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, string qualification, int yearOfExperience, DateTime dateOfJoining) : base(personID, name, fatherName, phone, mail, dob, gender)
        {
            s_principalID++;
            PrincipalID = "PRID" + s_principalID;

            Qualification = qualification;
            YearOfExperience = yearOfExperience;
            DateOfJoining = dateOfJoining;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"|{PersonID}|{Name}|{FatherName}|{Phone}|{Mail}|{DOB:dd/MM/yyyy}|{Gender}|{PrincipalID}|{Qualification}|{YearOfExperience}|{DateOfJoining:dd/MM/yyyy}");

        }
    }
}