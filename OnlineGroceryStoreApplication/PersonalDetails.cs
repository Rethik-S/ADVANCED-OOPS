using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreApplication
{
    public enum Gender { Select, Male, Female }
    public class PersonalDetails
    {



        //props
        /// <summary>
        /// Name Property used to hold a  Name of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// FatherName Property used to hold a FatherName of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// Gender Property used to hold a Gender of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Mobile Property used to hold a Mobile of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// DOB Property used to hold a DOB of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public DateTime DOB { get; set; }
        /// <summary>
        /// MailID Property used to hold a MailID of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string MailID { get; set; }

        //constructor

        /// <summary>
        ///  Constructor PersonalDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="name">name used to store data in the associated property</param>
        /// <param name="fatherName">fatherName used to store data in the associated property</param>
        /// <param name="gender">gender used to store data in the associated property</param>
        /// <param name="mobile">mobile used to store data in the associated property</param>
        /// <param name="dOB">dOB used to store data in the associated property</param>
        /// <param name="mailID">mailID used to store data in the associated property</param>
        public PersonalDetails(string name, string fatherName, Gender gender, string mobile, DateTime dOB, string mailID)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            DOB = dOB;
            MailID = mailID;
        }

        public PersonalDetails()
        {}
    }
}