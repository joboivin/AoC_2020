namespace Day5Solver
{
    internal abstract class Finder
    {
        private readonly int _startPosition;
        private readonly int _length;
        private readonly char _lowerHalf;
        private readonly char _higherHalf;
        private readonly int _maxNumber;

        protected Finder(int startPosition, int length, char lowerHalf, char higherHalf, int maxNumber)
        {
            _startPosition = startPosition;
            _length = length;
            _lowerHalf = lowerHalf;
            _higherHalf = higherHalf;
            _maxNumber = maxNumber;
        }

        public int FindNumber(string seatNumber)
        {
            const int initialDivisor = 2;

            var number = 0;
            var divisor = initialDivisor;

            for (var i = _startPosition; i < _startPosition + _length; i++)
            {
                if (seatNumber[i] == _higherHalf)
                    number += _maxNumber / divisor;

                divisor *= 2;
            }

            return number;
        }
    }
}
