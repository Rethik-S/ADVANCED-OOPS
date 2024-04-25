using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClass3
{
    public class PersonalInfo
    {
        

        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }
        public string Gender { get; set; }

        public PersonalInfo(string name, string fatherName, string mobile, string mail, string gender)
        {
            Name = name;
            FatherName = fatherName;
            Mobile = mobile;
            Mail = mail;
            Gender = gender;
        }

        public virtual void Update(string name, string fatherName, string mobile, string mail, string gender)
        {
            Name = name;
            FatherName = fatherName;
            Mobile = mobile;
            Mail = mail;
            Gender = gender;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Name}|{FatherName}|{Mobile}|{Mail}|{Gender}");
            
        }

    }
}