using System;

namespace Day4Solver.Passport
{
    internal class Passport
    {
        private BirthYear _birthYear;
        private IssueYear _issueYear;
        private ExpirationYear _expirationYear;
        private Height _height;
        private HairColor _hairColor;
        private EyeColor _eyeColor;
        private PassportID _passportID;
        private CountryID _countryID;

        public void SetBirthYear(string birthYear)
        {
            if (_birthYear != null)
                throw new Exception("Birth Year already set");

            _birthYear = new BirthYear(birthYear);
        }

        public void SetIssueYear(string issueYear)
        {
            if (_issueYear != null)
                throw new Exception("Issue Year already set");

            _issueYear = new IssueYear(issueYear);
        }

        public void SetExpirationYear(string expirationYear)
        {
            if (_expirationYear != null)
                throw new Exception("Expiration Year already set");

            _expirationYear = new ExpirationYear(expirationYear);
        }

        public void SetHeight(string height)
        {
            if (_height != null)
                throw new Exception("Height already set");

            _height = new Height(height);
        }

        public void SetHairColor(string hairColor)
        {
            if (_hairColor != null)
                throw new Exception("Hair Color already set");

            _hairColor = new HairColor(hairColor);
        }

        public void SetEyeColor(string eyeColor)
        {
            if (_eyeColor != null)
                throw new Exception("Eye Color already set");

            _eyeColor = new EyeColor(eyeColor);
        }

        public void SetPassportID(string passportID)
        {
            if (_passportID != null)
                throw new Exception("Passport ID already set");

            _passportID = new PassportID(passportID);
        }

        public void SetCountryID(string countryID)
        {
            if (_countryID != null)
                throw new Exception("Country ID already set");

            _countryID = new CountryID(countryID);
        }

        public bool IsValid()
        {
            return (_birthYear?.IsValid() ?? false) && (_issueYear?.IsValid() ?? false) && (_expirationYear?.IsValid() ?? false) &&
                   (_height?.IsValid() ?? false) && (_hairColor?.IsValid() ?? false) && (_eyeColor?.IsValid() ?? false) &&
                   (_passportID?.IsValid() ?? false);
        }

        public bool IsValidForBonus()
        {
            return (_birthYear?.IsValidForBonus() ?? false) && (_issueYear?.IsValidForBonus() ?? false) && (_expirationYear?.IsValidForBonus() ?? false) &&
                   (_height?.IsValidForBonus() ?? false) && (_hairColor?.IsValidForBonus() ?? false) && (_eyeColor?.IsValidForBonus() ?? false) &&
                   (_passportID?.IsValidForBonus() ?? false);
        }
    }
}
