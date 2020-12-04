using System.Text.RegularExpressions;

namespace Day4Solver.Passport
{
    internal class PassportID
    {
        private readonly string _internalPassportID;

        public PassportID(string passportID)
        {
            _internalPassportID = passportID;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_internalPassportID);
        }

        public bool IsValidForBonus()
        {
            var passportIDPattern = "^([0-9]){9}$";
            var passportIDRegex = new Regex(passportIDPattern);

            return IsValid() && passportIDRegex.IsMatch(_internalPassportID);
        }
    }
}
