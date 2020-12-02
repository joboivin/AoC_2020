using System;
using System.Collections.Generic;
using System.IO;

namespace Day1Solver
{
    internal class InputProvider : IInputProvider
    {
        private const string InputFilePath = @"Input\Day1.txt";

        public IEnumerable<int> ProvideInput()
        {
            using var reader = new StreamReader(InputFilePath);

            string line;
            while ((line = reader.ReadLine()) != null)
                yield return Convert.ToInt32(line);
        }
    }
}