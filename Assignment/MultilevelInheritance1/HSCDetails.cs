using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace MultilevelInheritance1
{
    public class HSCDetails : StudentInfo
    {
        private static int s_hscMarkSheetNumber = 2000;



        public string HSCMarksheetNumber { get; set; }

        public double PhysicsMark { get; set; }
        public double ChemistryMark { get; set; }
        public double MathsMark { get; set; }
        public double Total { get { return PhysicsMark + ChemistryMark + MathsMark; } }
        public double PercentageMarks { get { return Total / 3; } }

        public HSCDetails(string registerNumber, string personID, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender, string standard, string branch, string academicYear, double physicsMark, double chemistryMark, double mathsMark) : base(registerNumber, personID, name, fatherName, phone, mail, dob, gender, standard, branch, academicYear)
        {
            s_hscMarkSheetNumber++;
            HSCMarksheetNumber = "HSC" + s_hscMarkSheetNumber;

            PhysicsMark = physicsMark;
            ChemistryMark = chemistryMark;
            MathsMark = mathsMark;
        }

        //Methods
        public void GetMarks(int physicsMark, int chemistryMark, int mathsMark)
        {
            PhysicsMark = physicsMark;
            ChemistryMark = chemistryMark;
            MathsMark = mathsMark;
            // Console.WriteLine($"|{PhysicsMark}|{ChemistryMark}|{MathsMark}|");

        }

        public double CalculateTotal()
        {
            return Total;
        }

        public double CalculatePercentage()
        {
            return PercentageMarks;
        }

        public void ShowMarksheet()
        {
            Console.WriteLine($"|{HSCMarksheetNumber}|{PhysicsMark}|{ChemistryMark}|{MathsMark}|{Total}|{PercentageMarks}|");


        }

    }
}