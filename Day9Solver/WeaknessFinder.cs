using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day9Solver
{
    internal class WeaknessFinder
    {
        private readonly IList<long> _numbers;

        public WeaknessFinder(IList<long> numbers)
        {
            _numbers = numbers;
        }

        public async Task<long> FindWeaknessAsync(long invalidNumber)
        {
            var attempts = new List<Task<long?>>();

            for (var i = 0; i < _numbers.Count; i++)
            {
                var indexToAttempt = i;
                attempts.Add(Task.Run(() => AttemptToFindWeakness(invalidNumber, indexToAttempt)));
            }

            var attemptsResult = await Task.WhenAll(attempts);

            return attemptsResult.Sum(r => r ?? 0);
        }

        private long? AttemptToFindWeakness(long invalidNumber, int index)
        {
            long total = 0;

            if (_numbers[index] == invalidNumber)
                return null;

            for (var i = index; i < _numbers.Count; i++)
            {
                total += _numbers[i];

                if (total == invalidNumber)
                    return ExtractWeakness(index, i);

                if (total > invalidNumber)
                    break;
            }

            return null;
        }

        private long ExtractWeakness(int lowIndex, int highIndex)
        {
            var numbersInWeakness = _numbers.Skip(lowIndex).Take(highIndex - lowIndex + 1).ToList();

            return numbersInWeakness.Min() + numbersInWeakness.Max();
        }
    }
}
