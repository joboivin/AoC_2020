using AutoFixture;
using FluentAssertions;
using System;
using Xunit;

namespace Day4SolverTests
{
    public class PassportTests
    {
        private static readonly IFixture Auto = new Fixture();

        [Fact]
        public void SetBirthYear_WhenAlreadySet_ThenException()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetBirthYear(Auto.Create<string>());

            var action = new Action(() => subject.SetBirthYear(Auto.Create<string>()));

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void SetIssueYear_WhenAlreadySet_ThenException()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetIssueYear(Auto.Create<string>());

            var action = new Action(() => subject.SetIssueYear(Auto.Create<string>()));

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void SetExpirationYear_WhenAlreadySet_ThenException()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetExpirationYear(Auto.Create<string>());

            var action = new Action(() => subject.SetExpirationYear(Auto.Create<string>()));

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void SetHeight_WhenAlreadySet_ThenException()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetHeight(Auto.Create<string>());

            var action = new Action(() => subject.SetHeight(Auto.Create<string>()));

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void SetHairColor_WhenAlreadySet_ThenException()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetHairColor(Auto.Create<string>());

            var action = new Action(() => subject.SetHairColor(Auto.Create<string>()));

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void SetEyeColor_WhenAlreadySet_ThenException()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetEyeColor(Auto.Create<string>());

            var action = new Action(() => subject.SetEyeColor(Auto.Create<string>()));

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void SetPassportID_WhenAlreadySet_ThenException()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetPassportID(Auto.Create<string>());

            var action = new Action(() => subject.SetPassportID(Auto.Create<string>()));

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void SetCountryID_WhenAlreadySet_ThenException()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetCountryID(Auto.Create<string>());

            var action = new Action(() => subject.SetCountryID(Auto.Create<string>()));

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void IsValid_WhenAllFieldsAreSet_ThenTrue()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetBirthYear(Auto.Create<string>());
            subject.SetIssueYear(Auto.Create<string>());
            subject.SetExpirationYear(Auto.Create<string>());
            subject.SetHeight(Auto.Create<string>());
            subject.SetHairColor(Auto.Create<string>());
            subject.SetEyeColor(Auto.Create<string>());
            subject.SetPassportID(Auto.Create<string>());
            subject.SetCountryID(Auto.Create<string>());

            var result = subject.IsValid();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenAllFieldsAreSetExceptBirthYear_ThenFalse()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetIssueYear(Auto.Create<string>());
            subject.SetExpirationYear(Auto.Create<string>());
            subject.SetHeight(Auto.Create<string>());
            subject.SetHairColor(Auto.Create<string>());
            subject.SetEyeColor(Auto.Create<string>());
            subject.SetPassportID(Auto.Create<string>());
            subject.SetCountryID(Auto.Create<string>());

            var result = subject.IsValid();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenAllFieldsAreSetExceptIssueYear_ThenFalse()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetBirthYear(Auto.Create<string>());
            subject.SetExpirationYear(Auto.Create<string>());
            subject.SetHeight(Auto.Create<string>());
            subject.SetHairColor(Auto.Create<string>());
            subject.SetEyeColor(Auto.Create<string>());
            subject.SetPassportID(Auto.Create<string>());
            subject.SetCountryID(Auto.Create<string>());

            var result = subject.IsValid();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenAllFieldsAreSetExceptExpirationYear_ThenFalse()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetBirthYear(Auto.Create<string>());
            subject.SetIssueYear(Auto.Create<string>());
            subject.SetHeight(Auto.Create<string>());
            subject.SetHairColor(Auto.Create<string>());
            subject.SetEyeColor(Auto.Create<string>());
            subject.SetPassportID(Auto.Create<string>());
            subject.SetCountryID(Auto.Create<string>());

            var result = subject.IsValid();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenAllFieldsAreSetExceptHeight_ThenFalse()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetBirthYear(Auto.Create<string>());
            subject.SetIssueYear(Auto.Create<string>());
            subject.SetExpirationYear(Auto.Create<string>());
            subject.SetHairColor(Auto.Create<string>());
            subject.SetEyeColor(Auto.Create<string>());
            subject.SetPassportID(Auto.Create<string>());
            subject.SetCountryID(Auto.Create<string>());

            var result = subject.IsValid();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenAllFieldsAreSetExceptHairColor_ThenFalse()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetBirthYear(Auto.Create<string>());
            subject.SetIssueYear(Auto.Create<string>());
            subject.SetExpirationYear(Auto.Create<string>());
            subject.SetHeight(Auto.Create<string>());
            subject.SetEyeColor(Auto.Create<string>());
            subject.SetPassportID(Auto.Create<string>());
            subject.SetCountryID(Auto.Create<string>());

            var result = subject.IsValid();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenAllFieldsAreSetExceptSetEyeColor_ThenFalse()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetBirthYear(Auto.Create<string>());
            subject.SetIssueYear(Auto.Create<string>());
            subject.SetExpirationYear(Auto.Create<string>());
            subject.SetHeight(Auto.Create<string>());
            subject.SetHairColor(Auto.Create<string>());
            subject.SetPassportID(Auto.Create<string>());
            subject.SetCountryID(Auto.Create<string>());

            var result = subject.IsValid();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenAllFieldsAreSetExceptPassportID_ThenFalse()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetBirthYear(Auto.Create<string>());
            subject.SetIssueYear(Auto.Create<string>());
            subject.SetExpirationYear(Auto.Create<string>());
            subject.SetHeight(Auto.Create<string>());
            subject.SetHairColor(Auto.Create<string>());
            subject.SetEyeColor(Auto.Create<string>());
            subject.SetCountryID(Auto.Create<string>());

            var result = subject.IsValid();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenAllFieldsAreSetExceptCountryID_ThenTrue()
        {
            var subject = new Day4Solver.Passport.Passport();
            subject.SetBirthYear(Auto.Create<string>());
            subject.SetIssueYear(Auto.Create<string>());
            subject.SetExpirationYear(Auto.Create<string>());
            subject.SetHeight(Auto.Create<string>());
            subject.SetHairColor(Auto.Create<string>());
            subject.SetEyeColor(Auto.Create<string>());
            subject.SetPassportID(Auto.Create<string>());

            var result = subject.IsValid();

            result.Should().BeTrue();
        }
    }
}
