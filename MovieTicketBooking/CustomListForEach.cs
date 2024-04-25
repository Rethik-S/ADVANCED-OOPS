using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace MovieTicketBooking
{
    public partial class CustomList<Type> : IEnumerable, IEnumerator
    {
        int position ;

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if (position < _count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;

        }

        public void Reset()
        {
            position = -1;
        }

        public object Current { get { return _array[position]; } }
    }
}