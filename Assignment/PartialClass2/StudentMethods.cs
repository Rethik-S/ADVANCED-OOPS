using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClass2
{
    public partial class Studentinfo
    {
        public int CalculateTotal()
        {
            return PhysicsMark + ChemistryMark + MathsMark;
        }

        public double CalculatePercentage()
        {
            return CalculateTotal() / 3;
        }

        public void Display()
        {
            Console.WriteLine($"Student ID: {StudentID}");
            Console.WriteLine($"Student Name: {StudentName}");
            Console.WriteLine($"Date of birth : {DateOfBirth:dd/MM/yyyy}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Physics Marks: {PhysicsMark}");
            Console.WriteLine($"Chemistry Marks: {ChemistryMark}");
            Console.WriteLine($"Maths Marks: {MathsMark}");
            Console.WriteLine($"Total : {CalculateTotal()}");
            Console.WriteLine($"Percentage: {CalculatePercentage()}");
            
        }
    }
}