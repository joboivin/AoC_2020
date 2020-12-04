using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day4Solver
{
    internal class InputProvider : IInputProvider
    {
        private readonly IRawInputProvider _rawInputProvider;

        public InputProvider(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public async Task<IReadOnlyCollection<Passport>> ProvideInputAsync()
        {
            var passports = new List<Passport>();
            Passport newPassport = null;

            await foreach (var rawInput in _rawInputProvider.ProvideRawInputAsync())
            {
                if (newPassport == null)
                {
                    newPassport = new Passport();
                    passports.Add(newPassport);
                }

                if (string.IsNullOrWhiteSpace(rawInput))
                    newPassport = null;
                else
                    SetPassportInfos(newPassport, rawInput);
            }

            return passports;
        }

        private void SetPassportInfos(Passport passport, string line)
        {
            const int lengthOfInfoCode = 3;
            const int lengthOfInfoCodeWithSeparator = lengthOfInfoCode + 1;

            var infoCode = line.Substring(0, lengthOfInfoCode);
            var nextSpace = line.IndexOf(' ');
            var info = nextSpace == -1 ? line.Substring(lengthOfInfoCodeWithSeparator) : line.Substring(lengthOfInfoCodeWithSeparator, nextSpace - lengthOfInfoCodeWithSeparator);
            SetPassportInfo(passport, infoCode, info);

            if (nextSpace != -1)
                SetPassportInfos(passport, line.Substring(info.Length + lengthOfInfoCodeWithSeparator + 1));
        }

        private void SetPassportInfo(Passport passport, string infoCode, string info)
        {
            switch (infoCode)
            {
                case "byr":
                    passport.SetBirthYear(info);
                    return;
                case "iyr":
                    passport.SetIssueYear(info);
                    return;
                case "eyr":
                    passport.SetExpirationYear(info);
                    return;
                case "hgt":
                    passport.SetHeight(info);
                    return;
                case "hcl":
                    passport.SetHairColor(info);
                    return;
                case "ecl":
                    passport.SetEyeColor(info);
                    return;
                case "pid":
                    passport.SetPassportID(info);
                    return;
                case "cid":
                    passport.SetCountryID(info);
                    return;
                default:
                    throw new Exception($"Invalid info code: {info}");
            }
        }
    }
}