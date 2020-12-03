using Day3Solver;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Day3SolverTests
{
    public class ForestTests
    {
        private readonly Forest _subject;

        public ForestTests()
        {
            _subject = new Forest
            {
                VisibleForest = new List<List<char>>
                {
                    new List<char> {'.', '.', '#', '#', '.', '.', '.', '.', '.', '.', '.'},
                    new List<char> {'#', '.', '.', '.', '#', '.', '.', '.', '#', '.', '.'},
                    new List<char> {'.', '#', '.', '.', '.', '.', '#', '.', '.', '#', '.'},
                    new List<char> {'.', '.', '#', '.', '#', '.', '.', '.', '#', '.', '#'}
                }
            };
        }

        [Fact]
        public void Visibility_ThenReturnsVisibleForestWidth()
        {
            var result = _subject.Visibility;

            result.Should().Be(11, "it's the Count of each row");
        }

        [Fact]
        public void IsOpenSquare_WhenXAndYAreInVisibleForestAndRepresentAnOpenSquare_ThenTrue()
        {
            var result = _subject.IsOpenSquare(1, 3);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsOpenSquare_WhenXAndYAreInVisibleForestAndRepresentATree_ThenFalse()
        {
            var result = _subject.IsOpenSquare(2, 0);

            result.Should().BeFalse();
        }

        [Fact]
        public void IsOpenSquare_WhenYIsInVisibleForestAndXGoesBeyondVisibleForest_ThenVisibleForestRepeatsItself()
        {
            var result = _subject.IsOpenSquare(15, 1);

            result.Should().BeFalse("with a Visibility of 11, position 15 should be the same as position 4 for x.");
        }

        [Fact]
        public void IsOpenSquare_WhenXIsInVisibleForestAndYGoesBeyondVisibleForest_ThenThrowsOutOfForestException()
        {
            var action = new Action(() => _subject.IsOpenSquare(15, 5));

            action.Should().Throw<OutOfForestException>();
        }
    }
}
