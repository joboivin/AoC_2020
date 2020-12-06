using System.Collections.Generic;
using System.Linq;

namespace Day6Solver
{
    internal class GroupAnswers
    {
        private readonly Dictionary<char, int> _answers;
        private int _numberOfIndividualsInGroup;

        public GroupAnswers()
        {
            _answers = new Dictionary<char, int>();
            _numberOfIndividualsInGroup = 0;
        }

        public void Answer(char question)
        {
            if (!_answers.ContainsKey(question))
                _answers.Add(question, 1);
            else
                _answers[question]++;
        }

        public int GetAnswersCount()
        {
            return _answers.Count;
        }

        public int GetAnswersCountForBonus()
        {
            return _answers.Values.Count(v => v == _numberOfIndividualsInGroup);
        }

        public void AddIndividualToGroup()
        {
            _numberOfIndividualsInGroup++;
        }
    }
}
