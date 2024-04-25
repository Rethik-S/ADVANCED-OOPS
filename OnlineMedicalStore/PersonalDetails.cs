using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class PersonalDetails
    {

        //Auto property

        /// <summary>
        /// Name Property used to hold a User's Name of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Age Property used to hold a User's Age of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// City Property used to hold a User's City of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// PhoneNumber Property used to hold a User's PhoneNumber of the instance of <see cref="PersonalDetails"/>
        /// </summary>
        public string PhoneNumber { get; set; }

        //Constructor
        /// <summary>
        /// Constructor PersonalDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="name">name used to store data in the associated property</param>
        /// <param name="age">age used to store data in the associated property</param>
        /// <param name="city">city used to store data in the associated property</param>
        /// <param name="phoneNumber">phoneNumber used to store data in the associated property</param>
        public PersonalDetails(string name, string age, string city, string phoneNumber)
        {
            Name = name;
            Age = age;
            City = city;
            PhoneNumber = phoneNumber;
        }

        public PersonalDetails()
        {
            
        }
        
    }
}