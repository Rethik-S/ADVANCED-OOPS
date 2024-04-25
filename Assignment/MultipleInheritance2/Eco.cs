using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleInheritance2
{
    public class Eco : Car, IBrand
    {
        private static int s_makingID = 1000;



        public string MakingID { get; }
        public string EngineNumber { get; set; }
        public string ChasisNumber { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }


        public Eco(string fuleType, int numberOfSeats, string color, double tankCapacity, double numberOfKmDriven, string engineNumber, string chasisNumber, string brandName, string modelName) : base(fuleType, numberOfSeats, color, tankCapacity, numberOfKmDriven)
        {
            s_makingID++;
            MakingID = "MID" + s_makingID;

            EngineNumber = engineNumber;
            ChasisNumber = chasisNumber;
            BrandName = brandName;
            ModelName = modelName;
        }


        public void ShowDetails()
        {

            Console.WriteLine($"{MakingID}|{BrandName}|{ModelName}|{EngineNumber}|{ChasisNumber}|{FuleType}|{NumberOfSeats}|{Color}|{TankCapacity}|{NumberOfKmDriven}");

        }
    }
}