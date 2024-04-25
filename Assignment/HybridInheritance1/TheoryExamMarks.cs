using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridInheritance1
{
    public class TheoryExamMarks:PersonalInfo
    {
        public TheoryExamMarks(string registrationNumber, string name, string fatherName, string phone, string mail, DateTime dob, Gender gender,List<int> sem1, List<int> sem2, List<int> sem3, List<int> sem4) : base(registrationNumber, name, fatherName, phone, mail, dob, gender)
        {
            Sem1 = sem1;
            Sem2 = sem2;
            Sem3 = sem3;
            Sem4 = sem4;
        }

        public List<int> Sem1 { get; set; }
        public List<int> Sem2 { get; set; }
        public List<int> Sem3 { get; set; }
        public List<int> Sem4 { get; set; }

        
    }
}