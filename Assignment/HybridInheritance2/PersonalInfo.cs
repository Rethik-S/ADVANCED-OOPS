using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridInheritance2
{
    public class PersonalInfo
    {


        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }

        public PersonalInfo(string name, string gender, DateTime dOB, string phone, string mobile)
        {
            Name = name;
            Gender = gender;
            DOB = dOB;
            this.phone = phone;
            this.mobile = mobile;
        }
    }
}