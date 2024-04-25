using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polymorphism4
{
    public class FreeLancer : PersonDetails
    {


        public string Role { get; set; }
        public double SalaryAmount { get; set; }
        public int NoOfWorkingDays { get; set; }

        public FreeLancer(string name, string fatherName, string gender, string qualification, string role, int noOfWorkingDays) : base(name, fatherName, gender, qualification)
        {
            Role = role;
            NoOfWorkingDays = noOfWorkingDays;
        }

        public virtual void CalculateSalary()
        {
            SalaryAmount = NoOfWorkingDays * 500;
        }

        public virtual void Display()
        {
            Console.WriteLine($"{Name}|{FatherName}|{Gender}|{Qualification}|{Role}|{SalaryAmount}|{NoOfWorkingDays}|");

        }


    }
}