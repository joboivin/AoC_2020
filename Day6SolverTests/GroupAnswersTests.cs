using Day6Solver;
using FluentAssertions;
using Xunit;

namespace Day6SolverTests
{
    public class GroupAnswersTests
    {
        private readonly GroupAnswers _subject;

        public GroupAnswersTests()
        {
            _subject = new GroupAnswers();
        }

        [Fact]
        public void Answer_WhenAnswer1Question_ThenQuestionsCountIs1()
        {
            const char question = 'e';

            _subject.Answer(question);
            var result = _subject.GetAnswersCount();

            result.Should().Be(1);
        }

        [Fact]
        public void Answer_When2AnswersForTheSameQuestion_ThenQuestionsCountIs1()
        {
            const char question = 'e';

            _subject.Answer(question);
            _subject.Answer(question);
            var result = _subject.GetAnswersCount();

            result.Should().Be(1);
        }

        [Fact]
        public void Answer_When2AnswersFor2DifferentQuestions_ThenQuestionsCountIs2()
        {
            const char question1 = 'e';
            const char question2 = 'f';

            _subject.Answer(question1);
            _subject.Answer(question2);
            var result = _subject.GetAnswersCount();

            result.Should().Be(2);
        }
    }
}
