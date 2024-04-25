using System;
namespace MultilevelInheritance1;
public class Program
{
    public static void Main(string[] args)
    {
        //object creation using person object
        PersonalInfo person1 = new PersonalInfo("Tony", "Howard", "987654322", "tony@gmail.com", new DateTime(2000, 1, 1), Gender.Male);
        PersonalInfo person2 = new PersonalInfo("Bruce", "Banner", "987652832", "bruce@gmail.com", new DateTime(1998, 2, 3), Gender.Male);

        StudentInfo student1 = new StudentInfo(person1.PersonID, person1.Name, person1.FatherName, person1.Phone, person1.Mail, person1.DOB, person1.Gender, "12", "CS", "2018-2019");
        StudentInfo student2 = new StudentInfo(person2.PersonID, person2.Name, person2.FatherName, person2.Phone, person2.Mail, person2.DOB, person2.Gender, "12", "CS", "2016-2017");

        //object creation using getStudent info to get details
        StudentInfo student3 = new StudentInfo();
        student3.GetStudentInfo("mark", "henry", "987324332", "maek@gmail.com", new DateTime(1998, 2, 3), Gender.Male,"12", "CS", "2016-2017");

        student1.ShowInfo();
        student2.ShowInfo();
        student3.ShowInfo();

        HSCDetails hscDetails1 = new HSCDetails(student1.RegisterNumber, student1.PersonID, student1.Name, student1.FatherName, student1.Phone, student1.Mail, student1.DOB, student1.Gender, student1.Standard, student1.Branch, student1.AcademicYear, 90, 90, 90);
        HSCDetails hscDetails2 = new HSCDetails(student2.RegisterNumber, student2.PersonID, student2.Name, student2.FatherName, student2.Phone, student2.Mail, student2.DOB, student2.Gender, student2.Standard, student2.Branch, student2.AcademicYear, 80, 70, 90);

        
        Console.WriteLine($"{hscDetails1.PercentageMarks}");
        hscDetails1.GetMarks(90,90,90);
        Console.WriteLine($"{hscDetails1.CalculateTotal()}");
        hscDetails1.ShowMarksheet();
        hscDetails2.ShowMarksheet();


    }
}