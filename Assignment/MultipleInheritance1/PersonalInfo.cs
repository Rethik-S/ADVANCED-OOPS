using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleInheritance1
{
    public enum MaritalDetails { Select, Married, Single }
    public class PersonalInfo : IShowData
    {

        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public MaritalDetails MaritalDetails { get; set; }

        public PersonalInfo(string name, string gender, DateTime dOB, string phone, string mobile, MaritalDetails maritalDetails)
        {
            Name = name;
            Gender = gender;
            DOB = dOB;
            Phone = phone;
            Mobile = mobile;
            MaritalDetails = maritalDetails;
        }

        public virtual void ShowInfo()
        {
            Console.Write($"|{Name}|{Gender}|{DOB:dd/MM/yyyy}|{Phone}|{Mobile}|{MaritalDetails}|");
        }
    }

}