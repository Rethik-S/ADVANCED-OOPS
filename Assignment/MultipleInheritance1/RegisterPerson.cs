using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleInheritance1
{
    public class RegisterPerson : PersonalInfo, IShowData, IFamilyInfo
    {
        private static int s_registrationNumber = 1000;


        public string RegistrationNumber { get; }
        public DateTime DateOfRegistration { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string HouseAddress { get; set; }
        public int NoOfSiblings { get; set; }

        public RegisterPerson(string name, string gender, DateTime dOB, string phone, string mobile, MaritalDetails maritalDetails, string fatherName, string motherName, string houseAddress, int noOfSiblings, DateTime dateOfRegistration) : base(name, gender, dOB, phone, mobile, maritalDetails)
        {
            s_registrationNumber++;
            RegistrationNumber = "RP" + s_registrationNumber;
            
            FatherName = fatherName;
            MotherName = motherName;
            HouseAddress = houseAddress;
            NoOfSiblings = noOfSiblings;
            DateOfRegistration = dateOfRegistration;
        }

        public override void ShowInfo(){
            base.ShowInfo();
            Console.WriteLine($"{FatherName}|{MotherName}|{HouseAddress}|{NoOfSiblings}|{DateOfRegistration:dd/MM/yyyy}|{RegistrationNumber}|");
            
        }
    }
}