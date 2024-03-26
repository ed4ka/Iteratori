using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    internal class Book
    {
        public string Title { get; }
        public int Year { get; }
        public IReadOnlyList<string> Authors { get; }

        public Book(string title, int year,params string [] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }
    }
}
