using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha3
{
    internal class ListyIterator<T>
    {
        private List<T> collection;
        private int currentIndex;

        public ListyIterator(List<T> collection)
        {
            this.collection = collection;
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            return currentIndex < collection.Count - 1;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(collection[currentIndex]);
        }
    }
}
