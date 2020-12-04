namespace Day4Solver.Passport
{
    internal class BirthYear
    {
        private readonly string _internalBirthYear;

        public BirthYear(string birthYear)
        {
            _internalBirthYear = birthYear;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_internalBirthYear);
        }

        public bool IsValidForBonus()
        {
            return IsValid() && _internalBirthYear.Length == 4 &&
                   int.TryParse(_internalBirthYear, out var birthYearAsInt) && birthYearAsInt >= 1920 && birthYearAsInt <= 2002;
        }
    }
}
