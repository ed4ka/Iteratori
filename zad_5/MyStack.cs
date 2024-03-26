using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha5
{
    internal class MyStack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public MyStack()
        {
            elements = new List<T>();
        }

        public void Push(T element)
        {
            elements.Add(element);
        }

        public T Pop()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T poppedElement = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return poppedElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}

