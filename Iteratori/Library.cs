﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    internal class Library : IEnumerable<Book>
    {
        private IEnumerable<Book> books;

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public void Dispose() { }
            public bool MoveNext() => ++this.currentIndex< this.books.Count;
            public void Reset() => this.currentIndex = -1;
            public Book Current => this.books[this.currentIndex];
            object IEnumerator.Current => this.Current;
         }
    }
}
