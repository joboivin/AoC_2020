namespace Day4Solver.Passport
{
    internal class IssueYear
    {
        private readonly string _internalIssueYear;

        public IssueYear(string issueYear)
        {
            _internalIssueYear = issueYear;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_internalIssueYear);
        }

        public bool IsValidForBonus()
        {
            return IsValid() && _internalIssueYear.Length == 4 &&
                   int.TryParse(_internalIssueYear, out var issueYearAsInt) && issueYearAsInt >= 2010 && issueYearAsInt <= 2020;
        }
    }
}
