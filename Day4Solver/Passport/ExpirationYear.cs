namespace Day4Solver.Passport
{
    internal class ExpirationYear
    {
        private readonly string _internalExpirationYear;

        public ExpirationYear(string expirationYear)
        {
            _internalExpirationYear = expirationYear;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_internalExpirationYear);
        }

        public bool IsValidForBonus()
        {
            return IsValid() && _internalExpirationYear.Length == 4 &&
                   int.TryParse(_internalExpirationYear, out var expirationYearAsInt) && expirationYearAsInt >= 2020 && expirationYearAsInt <= 2030;
        }
    }
}
