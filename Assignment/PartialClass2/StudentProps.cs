using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClass2
{
    public enum Gender { Select, Male, Female, Others }
    public partial class Studentinfo
    {
        //field
        private static int s_studentID = 3000;

        //Auto property
        public string StudentID { get; }//read only property
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int PhysicsMark { get; set; }
        public int ChemistryMark { get; set; }
        public int MathsMark { get; set; }
    }
}