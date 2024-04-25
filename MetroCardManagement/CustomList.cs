using System;
using System.Collections.Generic;

namespace MetroCardManagement
{
    public partial class CustomList<Type>
    {
        //field

        /// <summary>
        ///  private field _count used to hold number of element present of the instance of <see cref="CustomList"/>
        /// </summary>
        private int _count;


        /// <summary>
        ///  private field _capacity used to hold capacity of the instance of <see cref="CustomList"/>
        /// </summary>
        private int _capacity;
        private Type[] _array;

        // auto property

        /// <summary>
        /// Count Property used to hold number of element present of the instance of <see cref="CustomList"/>
        /// </summary>
        public int Count { get { return _count; } }
        /// <summary>
        /// Capacity Property used to hold capacity of the instance of <see cref="CustomList"/>
        /// </summary>
        public int Capacity { get { return _capacity; } }
        /// <summary>
        /// private field _array used to hold elements of the instance of <see cref="CustomList"/>
        /// </summary>

        /// <summary>
        /// this property used to hold element of the instance of <see cref="CustomList"/>
        /// </summary>
        /// <value></value>
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        /// <summary>
        /// Constructor CustomList used to initialize values
        /// </summary>
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }
        /// <summary>
        /// Constructor CustomList used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="size"></param>
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }

        /// <summary>
        /// Add used to Add elements to the Instance of <see cref="UserDetails"/>
        /// </summary>
        /// <param name="element">element is used to pass the associated data</param>
        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = element;
            _count++;
        }

        /// <summary>
        /// GrowSize used to grow capacity of the Instance of <see cref="UserDetails"/>
        /// </summary>
        void GrowSize()
        {
            _capacity = _capacity * 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        /// <summary>
        /// AddRange used to Add list to the Instance of <see cref="UserDetails"/>
        /// </summary>
        /// <param name="elements">elements is used to pass the associated data</param>
        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count + elements.Count + 4;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            int k = 0;
            for (int i = _count; i < _count + elements.Count; i++)
            {
                temp[i] = elements[k];
                k++;
            }
            _array = temp;
            _count = _count + elements.Count;
        }
    }
}
