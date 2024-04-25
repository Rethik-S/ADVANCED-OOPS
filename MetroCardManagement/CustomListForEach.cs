using System;
using System.Collections;

namespace MetroCardManagement
{
    public partial class CustomList<Type> : IEnumerable, IEnumerator
    {
        /// <summary>
        /// field position used to hold position of the instance of <see cref="CustomList"/>
        /// </summary>
        int position;

        /// <summary>
        /// GetEnumerator used to iterate elements of the instance of <see cref="CustomList"/>
        /// </summary>
        /// <returns>the element of </returns>
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return (IEnumerator)this;
        }

        /// <summary>
        /// MoveNext used to Move Next position of the instance of <see cref="CustomList"/>
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Reset used to Reset position of the instance of <see cref="CustomList"/>
        /// </summary>
        public void Reset()
        {
            position = -1;
        }
        

        /// <summary>
        /// Current used to get element of the instance of <see cref="CustomList"/>
        /// </summary>
        /// <value></value>
        public object Current { get { return _array[position]; } }

    }
}