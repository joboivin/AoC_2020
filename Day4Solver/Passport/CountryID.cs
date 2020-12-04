namespace Day4Solver.Passport
{
    internal class CountryID
    {
        private readonly string _internalCountryID;

        public CountryID(string countryID)
        {
            _internalCountryID = countryID;
        }

        public bool IsValid()
        {
            return true;
        }

        public bool IsValidForBonus()
        {
            return IsValid();
        }
    }
}
