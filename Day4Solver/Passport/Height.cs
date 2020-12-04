namespace Day4Solver.Passport
{
    internal class Height
    {
        private readonly string _internalHeight;

        public Height(string height)
        {
            _internalHeight = height;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_internalHeight);
        }

        public bool IsValidForBonus()
        {
            if (!IsValid())
                return false;

            var isCm = _internalHeight.EndsWith("cm");
            var isIn = _internalHeight.EndsWith("in");

            if (isIn)
                return IsInValid();

            if (isCm)
                return IsCmValid();

            return false;
        }

        private bool IsCmValid()
        {
            var cm = _internalHeight.Substring(0, _internalHeight.Length - 2);

            return int.TryParse(cm, out var cmAsInt) && cmAsInt >= 150 && cmAsInt <= 193;
        }

        private bool IsInValid()
        {
            var inString = _internalHeight.Substring(0, _internalHeight.Length - 2);

            return int.TryParse(inString, out var inAsInt) && inAsInt >= 59 && inAsInt <= 76;
        }
    }
}
