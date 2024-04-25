using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClass2
{
    public sealed class PatientInfo
    {
        private static int s_patientID=1000;

        public string PatientID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int BedNo { get; set; }
        public string NativePlace { get; set; }
        public string AdmittedFor { get; set; }

        public PatientInfo(string name, string fatherName, int bedNo, string nativePlace, string admittedFor)
        {
            s_patientID++;
            PatientID = "PID"+s_patientID;

            Name = name;
            FatherName = fatherName;
            BedNo = bedNo;
            NativePlace = nativePlace;
            AdmittedFor = admittedFor;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{PatientID}|{Name}|{FatherName}|{BedNo}|{NativePlace}|{AdmittedFor}");
            
        }
    }
}