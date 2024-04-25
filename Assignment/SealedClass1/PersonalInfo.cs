using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClass1
{
    public enum Gender { Selected, Male, Female, Other }

    public class PersonalInfo
    {
        //field
        private static int s_personID = 1000;

        //property
        public string PersonID { get; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }

        //constructor
        public PersonalInfo()
        {
            s_personID++;
            PersonID = "PID" + s_personID;
        }

        public void UpdateInfo(string name, string fatherName, string phone, string mail, DateTime dob, Gender gender)
        {
            Name = name;
            FatherName = fatherName;
            Phone = phone;
            Mail = mail;
            DOB = dob;
            Gender = gender;
        }
    }
}