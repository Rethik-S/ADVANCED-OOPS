using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polymorphism3
{
    public class CSEDepartment : Library
    {
        public override string AuthorName { get; set; }
        public override string BookName { get; set; }
        public override string PublisherName { get; set; }
        public override string Year { get; set; }
        public CSEDepartment() : base()
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{SerialNumber}|{AuthorName}|{BookName}|{PublisherName}|{Year}");
        }
        public override void SetBookInfo(string authorName, string bookName, string publisherName, string year)
        {
            AuthorName = authorName;
            BookName = bookName;
            PublisherName = publisherName;
            Year = year;
        }
    }
}