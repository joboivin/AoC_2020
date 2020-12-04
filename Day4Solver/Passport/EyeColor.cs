using System.Collections.Generic;

namespace Day4Solver.Passport
{
    internal class EyeColor
    {
        private readonly string _internalEyeColor;
        private readonly List<string> ValidEveColors = new List<string>
        {
            "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
        };

        public EyeColor(string eyeColor)
        {
            _internalEyeColor = eyeColor;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_internalEyeColor);
        }

        public bool IsValidForBonus()
        {
            return IsValid() && ValidEveColors.Contains(_internalEyeColor);
        }
    }
}
