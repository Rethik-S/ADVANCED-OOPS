using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polymorphism6
{
    public class ICICI:Bank
    {
        public override double GetIntresetInfo()
        {
            return 7.5;
        }
    }
}