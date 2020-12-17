using System;
using System.Text.RegularExpressions;

namespace Day16Solver
{
    internal class TicketField : ITicketField
    {
        private readonly int _firstMin;
        private readonly int _firstMax;
        private readonly int _secondMin;
        private readonly int _secondMax;

        public TicketField(string ticketLine)
        {
            var ticketRegex = new Regex(@"^(.*): (\d*)-(\d*) or (\d*)-(\d*)$");
            var match = ticketRegex.Match(ticketLine);

            Name = match.Groups[1].Value;
            _firstMin = Convert.ToInt32(match.Groups[2].Value);
            _firstMax = Convert.ToInt32(match.Groups[3].Value);
            _secondMin = Convert.ToInt32(match.Groups[4].Value);
            _secondMax = Convert.ToInt32(match.Groups[5].Value);
        }

        public string Name { get; }

        public bool IsValid(int value)
        {
            return (value >= _firstMin && value <= _firstMax) ||
                   (value >= _secondMin && value <= _secondMax);
        }
    }
}
