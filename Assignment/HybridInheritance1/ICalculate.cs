using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridInheritance1
{
    public interface ICalculate
    {
        public double ProjectMark { get; set; }

        public void CalculateUG();
    }
}