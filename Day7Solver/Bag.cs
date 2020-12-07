using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7Solver
{
    internal class Bag
    {
        private readonly Dictionary<string, int> _content;

        public Bag()
        {
            _content = new Dictionary<string, int>();
        }

        public void AddPotentialContent(string bagColor, int bagCapacity)
        {
            _content.Add(bagColor, bagCapacity);
        }

        public IReadOnlyCollection<string> Content
            => _content.Keys;

        public IEnumerable<Tuple<string, int>> ContentAndCount
            => _content.Select(c => new Tuple<string, int>(c.Key, c.Value));
    }
}
