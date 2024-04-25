using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridInheritance1
{
    public class Marksheet : TheoryExamMarks, ICalculate
    {
        private static int markSheetNumber = 1000;
        public string MarksheetNumber { get; }
        public DateTime DateOfIssue { get; set; }
        public List<double> Total { get; set; }
        public List<double> Percentage { get; set; }
        public double ProjectMark { get; set; }

        public Marksheet(double projectMark,DateTime dateOfIssue, string registrationNumber, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, List<int> sem1, List<int> sem2, List<int> sem3, List<int> sem4) : base(registrationNumber, name, fatherName, phone, mail, dob, gender, sem1, sem2, sem3, sem4)
        {
            markSheetNumber++;
            MarksheetNumber = "MID" + markSheetNumber;

            DateOfIssue = dateOfIssue;
            ProjectMark = projectMark;
            Total = new List<double>();
            Percentage = new List<double>();
        }

        public void CalculateUG()
        {
            double total = 0;
            foreach (int i in Sem1)
            {
                total += i;
            }
            Total.Add(total);
            Percentage.Add(total / 6);
            total = 0;
            foreach (int i in Sem2)
            {
                total += i;
            }
            Total.Add(total);
            Percentage.Add(total / 6);

            total = 0;
            foreach (int i in Sem3)
            {
                total += i;
            }
            Total.Add(total);
            Percentage.Add(total / 6);

            total = 0;
            foreach (int i in Sem4)
            {
                total += i;
            }
            Total.Add(total);
            Percentage.Add(total / 6);

        }
        public string ShowUGMarkSheet()
        {
            //Console.WriteLine(
            string ans = $"{MarksheetNumber}|{RegistrationNumber}|{Name}|{FatherName}|{Phone}|{DOB:dd/MM/yyyy}|{Gender}|{ProjectMark}|{Total[0]}|{Total[1]}|{Total[2]}|{Total[3]}|{Percentage[0]}|{Percentage[1]}|{Percentage[2]}|{Percentage[3]}|{DateOfIssue:dd/MM/yyyy}";
            return ans;
            
        }




    }
}