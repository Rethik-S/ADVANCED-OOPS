using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class MedicineDetails
    {
        //field
        // <summary>
        /// s_medicineID field used to increment a MedicineID of the instance of <see cref="MedicineDetails"/>
        /// </summary>
        private static int s_medicineID = 100;


        //Auto property
        /// <summary>
        /// MedicineID Property used to hold a Medicine ID of the instance of <see cref="MedicineDetails"/>
        /// </summary>
        public string MedicineID { get; }
        /// <summary>
        /// MedicineName Property used to hold a Medicine Name of the instance of <see cref="MedicineDetails"/>
        /// </summary>
        public string MedicineName { get; set; }
        /// <summary>
        /// AvailableCount Property used to hold a Medicine AvailableCount of the instance of <see cref="MedicineDetails"/>
        /// </summary>
        public int AvailableCount { get; set; }
        /// <summary>
        /// Price Property used to hold a Medicine Price of the instance of <see cref="MedicineDetails"/>
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// DateOfExpiry Property used to hold a Medicine DateOfExpiry of the instance of <see cref="MedicineDetails"/>
        /// </summary>
        public DateTime DateOfExpiry { get; set; }

        //constructor

        /// <summary>
        /// Constructor MedicineDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="medicineName">medicineName used to store data in the associated property</param>
        /// <param name="availableCount">availableCount used to store data in the associated property</param>
        /// <param name="price">price used to store data in the associated property</param>
        /// <param name="dateOfExpiry">dateOfExpiry used to store data in the associated property</param>
        public MedicineDetails(string medicineName, int availableCount, double price, DateTime dateOfExpiry)
        {
            s_medicineID++;
            MedicineID = "MD" + s_medicineID;

            MedicineName = medicineName;
            AvailableCount = availableCount;
            Price = price;
            DateOfExpiry = dateOfExpiry;
        }

        public MedicineDetails(string medicine)
        {
            string[] values = medicine.Split(",");
            s_medicineID=int.Parse(values[0].Remove(0,2));
            MedicineID = values[0];

            MedicineName = values[1];
            AvailableCount = int.Parse(values[2]);
            Price = double.Parse(values[3]);
            DateOfExpiry = DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
        }
    }
}