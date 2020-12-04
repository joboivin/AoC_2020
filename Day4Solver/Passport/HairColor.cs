using System.Text.RegularExpressions;

namespace Day4Solver.Passport
{
    internal class HairColor
    {
        private readonly string _internalHairColor;

        public HairColor(string hairColor)
        {
            _internalHairColor = hairColor;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_internalHairColor);
        }

        public bool IsValidForBonus()
        {
            var hairColorPattern = "^#([0-9]|[a-f]){6}$";
            var hairColorRegex = new Regex(hairColorPattern);

            return IsValid() && hairColorRegex.IsMatch(_internalHairColor);
        }
    }
}
