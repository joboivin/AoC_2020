using System.Collections.Generic;

namespace Day9Solver
{
    internal class XMasReader
    {
        private const int DefaultPreambleLength = 25;

        private readonly IList<long> _numbers;
        private readonly int _preambleLength;

        public XMasReader(IList<long> numbers)
            : this(numbers, DefaultPreambleLength)
        {
        }

        public XMasReader(IList<long> numbers, int preambleLength)
        {
            _numbers = numbers;
            _preambleLength = preambleLength;
        }

        public void Execute()
        {
            for (var i = _preambleLength; i < _numbers.Count; i++)
            {
                if (!IsValid(i))
                    throw new InvalidSequenceException(_numbers[i]);
            }
        }

        private bool IsValid(int index)
        {
            for (var i = index - _preambleLength; i < index; i++)
                for (var j = i + 1; j < index; j++)
                    if (_numbers[i] + _numbers[j] == _numbers[index] && _numbers[i] != _numbers[j])
                        return true;

            return false;
        }
    }
}
