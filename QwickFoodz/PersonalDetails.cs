using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    //enum
    public enum Gender { Select, Male, Female, Transgender }
    public class PersonalDetails
    {


        //Auto Property
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string MailID { get; set; }
        public string Location { get; set; }



        //Constructors
        public PersonalDetails(string name, string fatherName, Gender gender, string mobile, DateTime dOB, string mailID, string location)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            DOB = dOB;
            MailID = mailID;
            Location = location;
        }
        public PersonalDetails()
        {

        }
    }
}