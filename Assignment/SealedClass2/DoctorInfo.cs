using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClass2
{
    public class DoctorInfo//:PatientInfo - cannot derive from sealed type 
    {
        private static int s_doctorID=1000;   

        public string DoctorID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }

        public DoctorInfo(string name, string fatherName)
        {
            s_doctorID++;
            DoctorID="DOC"+s_doctorID;
            Name = name;
            FatherName = fatherName;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{DoctorID}|{Name}|{FatherName}");
            
        }
    }
}