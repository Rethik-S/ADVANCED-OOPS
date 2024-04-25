using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class PersonalDetails
    {

        //Auto property
        /// <summary>
        /// UserName Property used to hold a User's Name of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// PhoneNumber Property used to hold a User's Phone Number of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string PhoneNumber { get; set; }


        //Constructor

        /// <summary>
        /// Constructor PersonalDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="userName">userName used to store data in the associated property</param>
        /// <param name="phoneNumber">phoneNumber used to store data in the associated property</param>
        public PersonalDetails(string userName, string phoneNumber)
        {
            UserName = userName;
            PhoneNumber = phoneNumber;
        }
        public PersonalDetails()
        {

        }

    }
}