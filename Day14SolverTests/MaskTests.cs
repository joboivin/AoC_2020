using Day14Solver;
using FluentAssertions;
using Xunit;

namespace Day14SolverTests
{
    public class MaskTests
    {
        [Fact]
        public void GetValue_WhenMaskIsOnlyNoReplacement_ThenReturnsOriginalNumber()
        {
            const long input = 7;

            var subject = new Mask("XXX");

            var result = subject.GetValue(input);

            result.Should().Be(input);
        }

        [Fact]
        public void GetValue_WhenMaskIsOnlyNoReplacementAndHasMoreBinaryDigitsThanInput_ThenReturnsOriginalNumber()
        {
            const long input = 7;

            var subject = new Mask("XXXX");

            var result = subject.GetValue(input);

            result.Should().Be(input);
        }

        [Fact]
        public void GetValue_WhenMaskOneReplacement_ThenReturnsModifiedValue()
        {
            const long input = 7;

            var subject = new Mask("XX0X");

            var result = subject.GetValue(input);

            result.Should().Be(5, "101 in binary is 5");
        }

        [Fact]
        public void GetValue_WhenMaskContainsMultipleReplacements_ThenReturnsModifiedValue()
        {
            const long input = 7;

            var subject = new Mask("1X0X");

            var result = subject.GetValue(input);

            result.Should().Be(13, "1101 in binary is 13");
        }

        [Fact]
        public void GetValue_WhenMaskContainsMultipleReplacementsAndNumberAlreadyHasCorrectValues_ThenReturnsOriginalNumber()
        {
            const long input = 7;

            var subject = new Mask("X11X");

            var result = subject.GetValue(input);

            result.Should().Be(input);
        }

        [Theory]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 11, 73)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 101, 101)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 0, 64)]
        public void GetValue_WhenUsingExamplesFromAoC_ThenReturnsExceptedValue(string mask, long input, long expectedValue)
        {
            var subject = new Mask(mask);

            var result = subject.GetValue(input);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void GetValues_WhenMaskWithoutFloatingValueAndWithoutReplacement_ThenReturnsOnlyOriginalNumber()
        {
            const long input = 7;

            var subject = new Mask("0000");

            var result = subject.GetValues(input);

            result.Should().ContainSingle().Which.Should().Be(input);
        }

        [Fact]
        public void GetValues_WhenMaskWithoutFloatingValueAndWithOneReplacement_ThenReturnsOnly1NumberWhichIsModified()
        {
            const long input = 7;

            var subject = new Mask("1000");

            var result = subject.GetValues(input);

            result.Should().ContainSingle().Which.Should().Be(15, "1111 in binary is 15");
        }

        [Fact]
        public void GetValues_WhenMaskWithoutFloatingValueAndWithTwoReplacements_ThenReturnsOnly1NumberWhichIsModified()
        {
            const long input = 1;

            var subject = new Mask("1010");

            var result = subject.GetValues(input);

            result.Should().ContainSingle().Which.Should().Be(11, "1011 in binary is 11");
        }

        [Fact]
        public void GetValues_WhenMaskWith1FloatingValueAndWithoutReplacements_ThenReturns2Numbers()
        {
            const long input = 7;

            var subject = new Mask("00X0");

            var result = subject.GetValues(input);

            result.Should().HaveCount(2);
            result.Should().Contain(7, "111 in binary is 7");
            result.Should().Contain(5, "101 in binary is 5");
        }

        [Fact]
        public void GetValues_WhenMaskWith1FloatingValueAndWith1Replacement_ThenReturns2NumbersAffectedByReplacement()
        {
            const long input = 7;

            var subject = new Mask("10X0");

            var result = subject.GetValues(input);

            result.Should().HaveCount(2);
            result.Should().Contain(15, "1111 in binary is 15");
            result.Should().Contain(13, "1101 in binary is 13");
        }

        [Fact]
        public void GetValues_WhenMaskWith2FloatingValuesAndWithoutReplacements_ThenReturns4Numbers()
        {
            const long input = 7;

            var subject = new Mask("X0X0");

            var result = subject.GetValues(input);

            result.Should().HaveCount(4);
            result.Should().Contain(7, "0111 in binary is 7");
            result.Should().Contain(5, "0101 in binary is 5");
            result.Should().Contain(15, "1111 in binary is 15");
            result.Should().Contain(13, "1101 in binary is 13");
        }

        [Fact]
        public void GetValues_WhenUsingFirstExampleFromAoC_ThenReturnsExpectedResult()
        {
            var subject = new Mask("000000000000000000000000000000X1001X");

            var result = subject.GetValues(42);

            result.Should().HaveCount(4);
            result.Should().Contain(26);
            result.Should().Contain(27);
            result.Should().Contain(58);
            result.Should().Contain(59);
        }

        [Fact]
        public void GetValues_WhenUsingSecondExampleFromAoC_ThenReturnsExpectedResult()
        {
            var subject = new Mask("00000000000000000000000000000000X0XX");

            var result = subject.GetValues(26);

            result.Should().HaveCount(8);
            result.Should().Contain(16);
            result.Should().Contain(17);
            result.Should().Contain(18);
            result.Should().Contain(19);
            result.Should().Contain(24);
            result.Should().Contain(25);
            result.Should().Contain(26);
            result.Should().Contain(27);
        }
    }
}
