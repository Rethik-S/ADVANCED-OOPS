using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridInheritance1
{
    public enum Gender { Selected, Male, Female, Other }

    public class PersonalInfo
    {
        //field
        private static int s_registrationNumber = 1000;

        //property
        public string RegistrationNumber { get; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }

        //constructor
        public PersonalInfo(string name, string fatherName, string phone, string mail, DateTime dob, Gender gender)
        {
            s_registrationNumber++;
            RegistrationNumber = "PID" + s_registrationNumber;

            Name = name;
            FatherName = fatherName;
            Phone = phone;
            Mail = mail;
            DOB = dob;
            Gender = gender;
        }

        public PersonalInfo(string registrationNumber, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender)
        {
            RegistrationNumber = registrationNumber;
            Name = name;
            FatherName = fatherName;
            Phone = phone;
            Mail = mail;
            DOB = dob;
            Gender = gender;
        }
    }
}