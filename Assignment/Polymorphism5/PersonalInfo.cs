using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polymorphism5
{
    public abstract class PersonalInfo
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }

        public PersonalInfo()
        {
            
        }
        public PersonalInfo(string name, string fatherName, string mobileNumber, string gender)
        {
            Name = name;
            FatherName = fatherName;
            MobileNumber = mobileNumber;
            Gender = gender;
        }


        public abstract void Display();
        
    }
}