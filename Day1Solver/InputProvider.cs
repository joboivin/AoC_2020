using System;
using System.Collections.Generic;
using System.IO;

namespace Day1Solver
{
    internal class InputProvider : IInputProvider
    {
        private const string InputFilePath = @"Input\Day1.txt";

        public async IAsyncEnumerable<int> ProvideInputAsync()
        {
            using var reader = new StreamReader(InputFilePath);

            string line;
            while ((line = await reader.ReadLineAsync()) != null)
                yield return Convert.ToInt32(line);
        }
    }
}