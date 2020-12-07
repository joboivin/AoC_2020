using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7Solver
{
    internal class InputProvider : IInputProvider
    {
        private readonly IRawInputProvider _rawInputProvider;

        public InputProvider(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public Task<Dictionary<string, Bag>> ProvideInputAsync()
        {
            var bagRegex = new Regex(@"^(.*) bags contain (.*)\.$");

            return _rawInputProvider.ProvideRawInputAsync()
                .Select(input => bagRegex.Match(input))
                .ToDictionaryAsync(match => match.Groups[1].Value, match => ConvertToBag(match.Groups[2].Value))
                .AsTask();
        }

        private static Bag ConvertToBag(string contentOfBag)
        {
            var bag = new Bag();

            if (contentOfBag == "no other bags")
                return bag;

            var bagContent = contentOfBag.Split(", ");
            var bagContentRegex = new Regex(@"^(\d)* (.*) bags?$");

            foreach (var content in bagContent)
            {
                var match = bagContentRegex.Match(content);
                bag.AddPotentialContent(match.Groups[2].Value, Convert.ToInt32(match.Groups[1].Value));
            }

            return bag;
        }
    }
}