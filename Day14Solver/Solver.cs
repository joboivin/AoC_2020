using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day14Solver
{
    internal class Solver
    {
        private readonly IRawInputProvider _rawInputProvider;

        public Solver(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public async Task<long> SolveProblemAsync()
        {
            var memory = new Dictionary<int, long>();
            Mask currentMask = null;

            await foreach (var input in _rawInputProvider.ProvideRawInputAsync())
            {
                if (input.StartsWith("mask"))
                    currentMask = ExtractMask(input);
                else
                {
                    var (index, value) = ExtractMemoryInstruction(input);

                    memory[index] = currentMask.GetValue(value);
                }
            }

            return memory.Values.Sum();
        }

        private static Mask ExtractMask(string input)
        {
            const int startOfMask = 7;

            return new Mask(input.Substring(startOfMask));
        }

        private static (int index, long value) ExtractMemoryInstruction(string input)
        {
            var memoryInstructionRegex = new Regex(@"^mem\[(\d*)\] = (\d*)$");
            var match = memoryInstructionRegex.Match(input);

            return (Convert.ToInt32(match.Groups[1].Value), Convert.ToInt64(match.Groups[2].Value));
        }

        public async Task<long> SolveBonusProblemAsync()
        {
            var memory = new Dictionary<long, long>();
            Mask currentMask = null;

            await foreach (var input in _rawInputProvider.ProvideRawInputAsync())
            {
                if (input.StartsWith("mask"))
                    currentMask = ExtractMask(input);
                else
                {
                    var (index, value) = ExtractMemoryInstruction(input);

                    foreach (var indexInMemory in currentMask.GetValues(index))
                        memory[indexInMemory] = value;
                }
            }

            return memory.Values.Sum();
        }
    }
}
