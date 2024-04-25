using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleInheritance1
{
    public interface IFamilyInfo:IShowData
    {
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string HouseAddress { get; set; }
        public int NoOfSiblings { get; set; }

        public new void ShowInfo();
    }
}