using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha6
{
    internal class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(IEnumerable<int> stones)
        {
            this.stones = stones.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            var evenStones = stones.Where((stone, index) => index % 2 == 0).ToList();
            var oddStones = stones.Where((stone, index) => index % 2 != 0).ToList();

            evenStones.Sort();
            oddStones.Sort((a, b) => b.CompareTo(a));

            var result = new List<int>();

            for (int i = 0; i < evenStones.Count; i++)
            {
                result.Add(evenStones[i]);
            }

            for (int i = 0; i < oddStones.Count; i++)
            {
                result.Add(oddStones[i]);
            }

            return result.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
