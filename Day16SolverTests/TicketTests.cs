using Day16Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day16SolverTests
{
    public class TicketTests
    {
        [Fact]
        public void Ticket_When1Field_Then1FieldValue()
        {
            const string input = "8";

            var subject = new Ticket(input);

            subject.FieldsValue.Should().ContainSingle().Which.Should().Be(8);
        }

        [Fact]
        public void Ticket_When2Fields_Then2FieldsValue()
        {
            const string input = "8,12";

            var subject = new Ticket(input);

            subject.FieldsValue.Should().HaveCount(2)
                .And.Contain(8).And.Contain(12);
        }

        [Fact]
        public void Ticket_When3Fields_Then3FieldsValue()
        {
            const string input = "8,12,1234";

            var subject = new Ticket(input);

            subject.FieldsValue.Should().HaveCount(3)
                .And.Contain(8).And.Contain(12).And.Contain(1234);
        }

        [Fact]
        public void GetInvalidFields_When1FieldAndFieldIsInalid_ThenReturnsInvalidField()
        {
            const string input = "8";

            var ticketField = Substitute.For<ITicketField>();
            ticketField.IsValid(8).Returns(false);
            var subject = new Ticket(input);

            var result = subject.GetInvalidFields(new[] { ticketField });

            result.Should().ContainSingle().Which.Should().Be(8);
        }

        [Fact]
        public void GetInvalidFields_When1FieldAndFieldIsValid_ThenReturnsEmpty()
        {
            const string input = "8";

            var ticketField = Substitute.For<ITicketField>();
            ticketField.IsValid(8).Returns(true);
            var subject = new Ticket(input);

            var result = subject.GetInvalidFields(new[] { ticketField });

            result.Should().BeEmpty();
        }

        [Fact]
        public void GetInvalidFields_When2FieldsAndFieldsAreValid_ThenReturnsEmpty()
        {
            const string input = "8,12";

            var ticketField = Substitute.For<ITicketField>();
            ticketField.IsValid(8).Returns(true);
            ticketField.IsValid(12).Returns(true);
            var subject = new Ticket(input);

            var result = subject.GetInvalidFields(new[] { ticketField });

            result.Should().BeEmpty();
        }

        [Fact]
        public void GetInvalidFields_When2FieldsAnd1FieldIsInvalid_ThenReturnsInvalidField()
        {
            const string input = "8,12";

            var ticketField = Substitute.For<ITicketField>();
            ticketField.IsValid(8).Returns(true);
            ticketField.IsValid(12).Returns(false);
            var subject = new Ticket(input);

            var result = subject.GetInvalidFields(new[] { ticketField });

            result.Should().ContainSingle().Which.Should().Be(12);
        }

        [Fact]
        public void GetInvalidFields_When2FieldsAndBothFieldsAreInvalid_ThenReturnsInvalidFields()
        {
            const string input = "8,12";

            var ticketField = Substitute.For<ITicketField>();
            ticketField.IsValid(8).Returns(false);
            ticketField.IsValid(12).Returns(false);
            var subject = new Ticket(input);

            var result = subject.GetInvalidFields(new[] { ticketField });

            result.Should().HaveCount(2)
                .And.Contain(8).And.Contain(12);
        }

        [Fact]
        public void GetInvalidFields_When2FieldsAndFieldsAreValidForOneTicketFieldAndInvalidForAnother_ThenReturnsEmpty()
        {
            const string input = "8,12";

            var ticketField1 = Substitute.For<ITicketField>();
            var ticketField2 = Substitute.For<ITicketField>();
            ticketField1.IsValid(8).Returns(true);
            ticketField1.IsValid(12).Returns(false);
            ticketField2.IsValid(8).Returns(false);
            ticketField2.IsValid(12).Returns(true);
            var subject = new Ticket(input);

            var result = subject.GetInvalidFields(new[] { ticketField1, ticketField2 });

            result.Should().BeEmpty();
        }

        [Fact]
        public void GetInvalidFields_When2FieldsAndOneFieldIsInvalidForBothTicketFields_ThenReturnsInvalidField()
        {
            const string input = "8,12";

            var ticketField1 = Substitute.For<ITicketField>();
            var ticketField2 = Substitute.For<ITicketField>();
            ticketField1.IsValid(8).Returns(true);
            ticketField1.IsValid(12).Returns(false);
            ticketField2.IsValid(8).Returns(false);
            ticketField2.IsValid(12).Returns(false);
            var subject = new Ticket(input);

            var result = subject.GetInvalidFields(new[] { ticketField1, ticketField2 });

            result.Should().ContainSingle().And.Contain(12);
        }
    }
}
