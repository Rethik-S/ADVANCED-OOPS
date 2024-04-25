using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abstraction2
{
    public abstract class Library
    {
        protected static int s_serialNumber = 1000;


        public string SerialNumber { get; }

        public abstract string AuthorName { get; set; }
        public abstract string BookName { get; set; }
        public abstract string PublisherName { get; set; }
        public abstract string Year { get; set; }
        protected Library()
        {
            s_serialNumber++;
            SerialNumber="LIB"+s_serialNumber;
        }

        public abstract void SetBookInfo(string authorName, string bookName, string publisherName, string year);
        public abstract void DisplayInfo();
    }
}