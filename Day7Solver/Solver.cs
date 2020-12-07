using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day7Solver
{
    internal class Solver
    {
        private readonly IInputProvider _inputProvider;

        public Solver(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public async Task<int> SolveProblemAsync()
        {
            var bagsThatCanPotentialyContainAShinyGoldBag = new Dictionary<string, bool>();
            var allBags = await _inputProvider.ProvideInputAsync();

            foreach (var bag in allBags)
            {
                CheckIfBagCanPotentialyContain(bag.Key, "shiny gold", bagsThatCanPotentialyContainAShinyGoldBag, allBags);
            }

            return bagsThatCanPotentialyContainAShinyGoldBag.Count(b => b.Value);
        }

        public async Task<int> SolveBonusProblemAsync()
        {
            var totalNumberOfBagsRequiredParBag = new Dictionary<string, int>();
            var allBags = await _inputProvider.ProvideInputAsync();


            DetermineTotalNumberOfBagsPerBag("shiny gold", totalNumberOfBagsRequiredParBag, allBags);

            return totalNumberOfBagsRequiredParBag["shiny gold"];
        }

        private static bool CheckIfBagCanPotentialyContain(string bagColor, string desiredBagColor, IDictionary<string, bool> bagsThatCanPotentialyContainDesiredColor, IReadOnlyDictionary<string, Bag> allBags)
        {
            if (bagsThatCanPotentialyContainDesiredColor.ContainsKey(bagColor))
                return bagsThatCanPotentialyContainDesiredColor[bagColor];

            var bag = allBags[bagColor];

            if (bag.Content.Count == 0)
                bagsThatCanPotentialyContainDesiredColor.Add(bagColor, false);
            else if (bag.Content.Contains(desiredBagColor))
                bagsThatCanPotentialyContainDesiredColor.Add(bagColor, true);
            else
                bagsThatCanPotentialyContainDesiredColor.Add(bagColor,
                    bag.Content.Any(b => CheckIfBagCanPotentialyContain(b, desiredBagColor, bagsThatCanPotentialyContainDesiredColor, allBags)));

            return bagsThatCanPotentialyContainDesiredColor[bagColor];
        }

        private static int DetermineTotalNumberOfBagsPerBag(string bagColor, IDictionary<string, int> totalNumberOfBagsRequiredParBag, IReadOnlyDictionary<string, Bag> allBags)
        {
            if (totalNumberOfBagsRequiredParBag.ContainsKey(bagColor))
                return totalNumberOfBagsRequiredParBag[bagColor];

            var bag = allBags[bagColor];

            totalNumberOfBagsRequiredParBag.Add(bagColor, bag.ContentAndCount.Sum(
                        b => b.Item2 + b.Item2 * DetermineTotalNumberOfBagsPerBag(b.Item1, totalNumberOfBagsRequiredParBag, allBags)));

            return totalNumberOfBagsRequiredParBag[bagColor];
        }
    }
}
