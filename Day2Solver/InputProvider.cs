using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day2Solver
{
    internal class InputProvider : IInputProvider
    {
        private readonly IRawInputProvider _rawInputProvider;

        public InputProvider(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public IAsyncEnumerable<PasswordEntry> ProvideInputAsync()
        {
            var rawInput = _rawInputProvider.ProvideRawInputAsync();

            return rawInput.Select(ConvertToPasswordEntry);
        }

        private static PasswordEntry ConvertToPasswordEntry(string input)
        {
            const string passwordEntryPattern = @"^(\d*)-(\d*) ([a-z]): ([a-z]*)$";

            var passwordEntryRegex = new Regex(passwordEntryPattern);
            var match = passwordEntryRegex.Match(input);

            if (!match.Success)
                throw new Exception($"Input doesn't matches expected pattern : {input}");

            return new PasswordEntry
            {
                MinOccurence = Convert.ToInt32(match.Groups[1].Value),
                MaxOccurence = Convert.ToInt32(match.Groups[2].Value),
                MandatoryChar = Convert.ToChar(match.Groups[3].Value),
                Password = match.Groups[4].Value
            };
        }
    }
}