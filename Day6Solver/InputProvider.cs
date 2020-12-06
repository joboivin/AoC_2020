using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day6Solver
{
    internal class InputProvider : IInputProvider
    {
        private readonly IRawInputProvider _rawInputProvider;

        public InputProvider(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public async Task<IReadOnlyCollection<GroupAnswers>> ProvideInputAsync()
        {
            var groups = new List<GroupAnswers>();
            GroupAnswers newGroup = null;

            await foreach (var rawInput in _rawInputProvider.ProvideRawInputAsync())
            {
                if (newGroup == null)
                {
                    newGroup = new GroupAnswers();
                    groups.Add(newGroup);
                }

                if (string.IsNullOrWhiteSpace(rawInput))
                    newGroup = null;
                else
                    SetIndividualAnswer(newGroup, rawInput);
            }

            return groups;
        }

        private static void SetIndividualAnswer(GroupAnswers group, string line)
        {
            group.AddIndividualToGroup();

            foreach (var question in line)
                group.Answer(question);
        }
    }
}