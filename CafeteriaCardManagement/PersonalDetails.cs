using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{

    //enum

    /// <summary>
    ///  DataType Gender used to select a instance of <see cref="PersonalDetails" /> Gender Information
    /// </summary>
    public enum Gender { Select, Male, Female, Transgender }

    public class PersonalDetails
    {

        /*
            Name
            FatherName
            Gender {Enum - Select, Male, Female, Transgender}
            Mobile
            MailID
        */

        //Auto property

        /// <summary>
        /// Name Property used to hold a user's Name of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// FatherName Property used to hold a user's Father Name of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string FatherName { get; set; }

        /// <summary>
        /// Gender Property used to hold a user's Gender of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Mobile Property used to hold a user's Mobile number of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// MailID Property used to hold a user's MailID of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string MailID { get; set; }


        //constructor

        /// <summary>
        /// Constructor PersonalDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="name">name parameter used to assign value to its associated property</param>
        /// <param name="fatherName">fatherName parameter used to assign value to its associated property</param>
        /// <param name="gender">gender parameter used to assign value to its associated property</param>
        /// <param name="mobile">mobile parameter used to assign value to its associated property</param>
        /// <param name="mailID">mailID parameter used to assign value to its associated property</param>
        public PersonalDetails(string name, string fatherName, Gender gender, string mobile, string mailID)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            MailID = mailID;
        }

    }
}