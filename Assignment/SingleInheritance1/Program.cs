using System;
namespace SingleInheritance1;
public class Program
{
    public static void Main(string[] args)
    {
        
        PersonalInfo person1 = new PersonalInfo("Tony","Howard","987654322","tony@gmail.com",new DateTime(2000,1,1),Gender.Male);
        PersonalInfo person2 = new PersonalInfo("Bruce","Banner","987652832","bruce@gmail.com",new DateTime(1998,2,3),Gender.Male);

        StudentInfo student1 = new StudentInfo(person1.PersonID,person1.Name,person1.FatherName,person1.Phone,person1.Mail,person1.DOB,person1.Gender,"12","CS","2018-2019");
        StudentInfo student2 = new StudentInfo(person2.PersonID,person2.Name,person2.FatherName,person2.Phone,person2.Mail,person2.DOB,person2.Gender,"12","CS","2016-2017");

        student1.ShowStudentInfo();
        student2.ShowStudentInfo();
    }
}