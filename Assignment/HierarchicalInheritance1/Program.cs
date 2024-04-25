using System;
namespace HierarchicalInheritance1;
public class Program
{
    public static void Main(string[] args)
    {
        PersonalInfo person1 = new PersonalInfo("Tony", "Howard", "987654322", "tony@gmail.com", new DateTime(2000, 1, 1), Gender.Male);
        PersonalInfo person2 = new PersonalInfo("Bruce", "Banner", "987652832", "bruce@gmail.com", new DateTime(1998, 2, 3), Gender.Male);
        PersonalInfo person3 = new PersonalInfo("leo", "das", "983452832", "leo@gmail.com", new DateTime(1992, 5, 3), Gender.Male);
        PersonalInfo person4 = new PersonalInfo("antony", "mark", "984552832", "antony@gmail.com", new DateTime(2003, 12, 23), Gender.Male);
        PersonalInfo person5 = new PersonalInfo("harold", "das", "987653242", "harold@gmail.com", new DateTime(1988, 4, 30), Gender.Male);
        PersonalInfo person6 = new PersonalInfo("surya", "ramesh", "984353832", "surya@gmail.com", new DateTime(1977, 11, 13), Gender.Male);

        TeacherInfo teacher1 = new TeacherInfo(person1.PersonID,person1.Name,person1.FatherName,person1.Phone,person1.Mail,person1.DOB,person1.Gender,"cse","maths","M.E",3,new DateTime(2023,2,1));
        TeacherInfo teacher2 = new TeacherInfo(person2.PersonID,person2.Name,person2.FatherName,person2.Phone,person2.Mail,person2.DOB,person2.Gender,"eee","circuits","M.E",2,new DateTime(2023,2,1));

        StudentInfo student1 = new StudentInfo(person3.PersonID,person3.Name,person3.FatherName,person3.Phone,person3.Mail,person3.DOB,person3.Gender,"B.E","CSE","3");
        StudentInfo student2 = new StudentInfo(person4.PersonID,person4.Name,person4.FatherName,person4.Phone,person4.Mail,person4.DOB,person4.Gender,"B.E","EEE","2");

        PrincipalInfo principal = new PrincipalInfo(person5.PersonID,person5.Name,person5.FatherName,person5.Phone,person5.Mail,person5.DOB,person5.Gender,"M.tech",20,new DateTime(1999,2,2));

        teacher1.ShowDetails();
        teacher2.ShowDetails();
        student1.ShowDetails();
        student2.ShowDetails();
        principal.ShowDetails();
    }
}