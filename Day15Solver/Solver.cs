using System.Collections.Generic;
using System.Linq;

namespace Day15Solver
{
    internal class Solver
    {
        private readonly IList<int> _input;

        public Solver(IList<int> input)
        {
            _input = input;
        }

        public int SolveProblem()
        {
            return Solve(2020);
        }

        private int Solve(int whichNumberToDetermine)
        {
            var lastTurnNumberWasSaid = new Dictionary<int, int>();

            for (var i = 1; i <= _input.Count; i++)
                lastTurnNumberWasSaid.Add(_input[i - 1], i);

            var turnNo = _input.Count + 1;
            var lastNumberSaid = _input.Last();

            while (true)
            {
                var numberToSay = lastTurnNumberWasSaid.ContainsKey(lastNumberSaid)
                    ? turnNo - lastTurnNumberWasSaid[lastNumberSaid] - 1
                    : 0;

                //Assignation in Dictionnary is done on the next turn because we shouldn't count
                //the previous turn to determine if the number was already said, it would always
                //be true otherwise.
                lastTurnNumberWasSaid[lastNumberSaid] = turnNo - 1;
                lastNumberSaid = numberToSay;

                if (turnNo == whichNumberToDetermine)
                    return numberToSay;

                turnNo++;
            }
        }

        public int SolveBonusProblem()
        {
            return Solve(30000000);
        }
    }
}
