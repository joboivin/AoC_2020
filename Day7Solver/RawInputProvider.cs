using System.Collections.Generic;
using System.IO;

namespace Day7Solver
{
    internal class RawInputProvider : IRawInputProvider
    {
        private const string InputFilePath = @"Input\Day7.txt";

        public async IAsyncEnumerable<string> ProvideRawInputAsync()
        {
            using var reader = new StreamReader(InputFilePath);

            while (!reader.EndOfStream)
                yield return await reader.ReadLineAsync();
        }
    }
}