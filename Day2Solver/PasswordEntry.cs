using System.Linq;

namespace Day2Solver
{
    internal class PasswordEntry
    {
        public int MinOccurence { get; set; }
        public int MaxOccurence { get; set; }
        public char MandatoryChar { get; set; }
        public string Password { get; set; }

        public virtual bool IsValid
        {
            get
            {
                var mandatoryCharOccurence = Password.Where(c => c == MandatoryChar).ToList();

                return mandatoryCharOccurence.Count >= MinOccurence && mandatoryCharOccurence.Count <= MaxOccurence;
            }
        }
    }
}
