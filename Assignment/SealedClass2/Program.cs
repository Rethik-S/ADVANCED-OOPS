using System;
namespace SealedClass2;
public class Program{
    public static void Main(string[] args)
    {
        PatientInfo patientInfo = new PatientInfo("hari","sathish",20,"Chennai","Fever");
        patientInfo.DisplayInfo();

        DoctorInfo doctorInfo = new DoctorInfo("Suresh","Ramesh");
        doctorInfo.DisplayInfo();
    }
}