using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathsLib
{
    public class Maths
    {
        //Can be accessed inside the current namespace or can be accessed in this namespace and other classes that inherit Maths class from different namespace.
        protected internal double PI = 3.14;

        //can be accesed inside namespace
        internal double g = 9.8;
    }
}