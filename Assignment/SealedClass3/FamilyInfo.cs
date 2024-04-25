using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClass3
{
    public class FamilyInfo : PersonalInfo
    {
        public string MotherName { get; set; }
        public string NoOfSiblings { get; set; }
        public string NativePlace { get; set; }

        public FamilyInfo(string name, string fatherName, string mobile, string mail, string gender, string motherName, string noOfSiblings, string nativePlace) : base(name, fatherName, mobile, mail, gender)
        {
            MotherName = motherName;
            NoOfSiblings = noOfSiblings;
            NativePlace = nativePlace;
        }

        public sealed override void Update(string name, string fatherName, string mobile, string mail, string gender)
        {
            Name = name;
            FatherName = fatherName;
            Mobile = mobile;
            Mail = mail;
            Gender = gender;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Name}|{FatherName}|{Mobile}|{Mail}|{Gender}|{MotherName}|{NoOfSiblings}|{NativePlace}");
            
        }





    }
}