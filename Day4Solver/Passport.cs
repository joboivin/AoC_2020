using System;

namespace Day4Solver
{
    internal class Passport
    {
        private string _birthYear;
        private string _issueYear;
        private string _expirationYear;
        private string _height;
        private string _hairColor;
        private string _eyeColor;
        private string _passportID;
        private string _countryID;

        public void SetBirthYear(string birthYear)
        {
            if (_birthYear != null)
                throw new Exception("Birth Year already set");

            _birthYear = birthYear;
        }

        public void SetIssueYear(string issueYear)
        {
            if (_issueYear != null)
                throw new Exception("Issue Year already set");

            _issueYear = issueYear;
        }

        public void SetExpirationYear(string expirationYear)
        {
            if (_expirationYear != null)
                throw new Exception("Expiration Year already set");

            _expirationYear = expirationYear;
        }

        public void SetHeight(string height)
        {
            if (_height != null)
                throw new Exception("Height already set");

            _height = height;
        }

        public void SetHairColor(string hairColor)
        {
            if (_hairColor != null)
                throw new Exception("Hair Color already set");

            _hairColor = hairColor;
        }

        public void SetEyeColor(string eyeColor)
        {
            if (_eyeColor != null)
                throw new Exception("Eye Color already set");

            _eyeColor = eyeColor;
        }

        public void SetPassportID(string passportID)
        {
            if (_passportID != null)
                throw new Exception("Passport ID already set");

            _passportID = passportID;
        }

        public void SetCountryID(string countryID)
        {
            if (_countryID != null)
                throw new Exception("Country ID already set");

            _countryID = countryID;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_birthYear) && !string.IsNullOrWhiteSpace(_issueYear) &&
                   !string.IsNullOrWhiteSpace(_expirationYear) && !string.IsNullOrWhiteSpace(_height) &&
                   !string.IsNullOrWhiteSpace(_hairColor) && !string.IsNullOrWhiteSpace(_eyeColor) &&
                   !string.IsNullOrWhiteSpace(_passportID);
        }
    }
}
