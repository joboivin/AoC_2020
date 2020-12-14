using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14Solver
{
    internal class Mask
    {
        private readonly char[] _mask;

        public Mask(string mask)
        {
            _mask = mask.Reverse().ToArray();
        }

        public long GetValue(long input)
        {
            const char noReplacement = 'X';

            var inputAsChars = Convert.ToString(input, 2).Reverse().ToArray();
            var newValue = GetValueWithReplacements(inputAsChars, noReplacement);

            return Convert.ToInt64(new string(newValue.Reverse().ToArray()), 2);
        }

        private char[] GetValueWithReplacements(char[] valueToModify, char noReplacement)
        {
            var newValue = new char[_mask.Length];

            for (var i = 0; i < _mask.Length; i++)
            {
                if (_mask[i] != noReplacement)
                    newValue[i] = _mask[i];
                else
                {
                    if (i >= valueToModify.Length)
                        newValue[i] = '0';
                    else
                        newValue[i] = valueToModify[i];
                }
            }

            return newValue;
        }

        public IList<long> GetValues(long input)
        {
            const char noReplacement = '0';
            const char floatingValue = 'X';

            var inputAsChars = Convert.ToString(input, 2).Reverse().ToArray();
            var newValue = GetValueWithReplacements(inputAsChars, noReplacement).Reverse().ToArray();
            var initialValues = new List<char[]> { new char[] { } };

            var allValues = newValue.Aggregate(initialValues, (partialValues, valueByte) => valueByte == floatingValue
                   ? GetValuesWithoutFloatingByte(partialValues).ToList()
                   : partialValues.Select(partialValue => AddByte(partialValue, valueByte)).ToList());

            return allValues.Select(value => Convert.ToInt64(new string(value), 2)).ToList();
        }

        private IEnumerable<char[]> GetValuesWithoutFloatingByte(IList<char[]> partialValues)
        {
            foreach (var partialValue in partialValues)
            {
                yield return AddByte(partialValue, '0');
                yield return AddByte(partialValue, '1');
            }
        }

        private char[] AddByte(char[] initialValue, char byteToAdd)
        {
            return initialValue.Concat(new[] { byteToAdd }).ToArray();
        }
    }
}
