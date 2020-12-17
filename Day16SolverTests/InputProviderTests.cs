using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day16Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day16SolverTests
{
    public class InputProviderTests
    {
        private readonly IRawInputProvider _rawInputProvider;

        private readonly InputProvider _subject;

        public InputProviderTests()
        {
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new InputProvider(_rawInputProvider);
        }

        [Fact]
        public async Task ProviderInputAsync_WhenUsingInputFromAoC_ThenTicketFieldsAreOK()
        {
            SetupRawInputProvider();

            var (result, _, _) = await _subject.ProvideInputAsync();

            result.Should().HaveCount(3)
                .And.Contain(t => t.Name == "class")
                .And.Contain(t => t.Name == "row")
                .And.Contain(t => t.Name == "seat");
        }

        [Fact]
        public async Task ProviderInputAsync_WhenUsingInputFromAoC_ThenMyTicketIsOK()
        {
            SetupRawInputProvider();

            var (_, result, _) = await _subject.ProvideInputAsync();

            result.FieldsValue.Should().HaveCount(3);
            AssertTicketIsOK(result, new List<int> { 7, 1, 14 });
        }

        [Fact]
        public async Task ProviderInputAsync_WhenUsingInputFromAoC_ThenNearbyTicketsAreOK()
        {
            SetupRawInputProvider();

            var (_, _, result) = await _subject.ProvideInputAsync();

            result.Should().HaveCount(4);
            AssertTicketIsOK(result[0], new List<int> { 7, 3, 47 });
            AssertTicketIsOK(result[1], new List<int> { 40, 4, 50 });
            AssertTicketIsOK(result[2], new List<int> { 55, 2, 20 });
            AssertTicketIsOK(result[3], new List<int> { 38, 6, 12 });
        }

        private void SetupRawInputProvider()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "class: 1-3 or 5-7",
                "row: 6-11 or 33-44",
                "seat: 13-40 or 45-50",
                "",
                "your ticket:",
                "7,1,14",
                "",
                "nearby tickets:",
                "7,3,47",
                "40,4,50",
                "55,2,20",
                "38,6,12"
            }.ToAsyncEnumerable());
        }

        private void AssertTicketIsOK(Ticket ticket, IList<int> expectedFields)
        {
            ticket.FieldsValue.Should().HaveSameCount(expectedFields);

            for (var i = 0; i < expectedFields.Count; i++)
                ticket.FieldsValue[i].Should().Be(expectedFields[i]);
        }
    }
}
