using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClass2
{
   public partial class Studentinfo
    {
         public Studentinfo(string studentName, string fatherName, DateTime dateOfBirth, Gender gender, int physicsMark, int chemistryMark, int mathsMark)
        {
            //Auto incrementation
            s_studentID++;
            StudentID = "SF" + s_studentID;

            StudentName = studentName;
            FatherName = fatherName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhysicsMark = physicsMark;
            ChemistryMark = chemistryMark;
            MathsMark = mathsMark;
        }
    }
}