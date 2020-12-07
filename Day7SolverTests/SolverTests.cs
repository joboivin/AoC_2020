using Day7Solver;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Day7SolverTests
{
    public class SolverTests
    {
        private readonly IInputProvider _inputProvider;

        private readonly Solver _subject;

        public SolverTests()
        {
            _inputProvider = Substitute.For<IInputProvider>();

            _subject = new Solver(_inputProvider);
        }

        [Fact]
        public async Task SolveProblemAsync_When1BagThatContainsNoBags_ThenReturns0()
        {
            _inputProvider.ProvideInputAsync().Returns(new Dictionary<string, Bag> { { "faded blue", new Bag() } });

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(0);
        }

        [Fact]
        public async Task SolveProblemAsync_When1BagThatContainsABagNotShinyGoldThatContainsNoBag_ThenReturns0()
        {
            var bag = new Bag();
            bag.AddPotentialContent("dotted black", 1);
            _inputProvider.ProvideInputAsync().Returns(new Dictionary<string, Bag> { { "faded blue", bag }, { "dotted black", new Bag() } });

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(0);
        }

        [Fact]
        public async Task SolveProblemAsync_When1BagThatContainsAShinyGoldBag_ThenReturns1()
        {
            var bag = new Bag();
            bag.AddPotentialContent("shiny gold", 1);
            _inputProvider.ProvideInputAsync().Returns(new Dictionary<string, Bag> { { "faded blue", bag }, { "shiny gold", new Bag() } });

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(1);
        }

        [Fact]
        public async Task SolveProblemAsync_When2BagsThatContainsAShinyGoldBag_ThenReturns2()
        {
            var bag1 = new Bag();
            bag1.AddPotentialContent("shiny gold", 1);
            var bag2 = new Bag();
            bag2.AddPotentialContent("shiny gold", 1);
            _inputProvider.ProvideInputAsync().Returns(new Dictionary<string, Bag> { { "faded blue", bag1 }, { "shiny gold", new Bag() }, { "dotted black", bag2 } });

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(2);
        }

        [Fact]
        public async Task SolveProblemAsync_When1BagThatContains1BagThatContainsAShinyGoldBag_ThenReturns2()
        {
            var bag1 = new Bag();
            bag1.AddPotentialContent("dotted black", 1);
            var bag2 = new Bag();
            bag2.AddPotentialContent("shiny gold", 1);
            _inputProvider.ProvideInputAsync().Returns(new Dictionary<string, Bag> { { "faded blue", bag1 }, { "shiny gold", new Bag() }, { "dotted black", bag2 } });

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(2);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_When1ShinyGoldBagWithNoContent_ThenReturns0()
        {
            _inputProvider.ProvideInputAsync().Returns(new Dictionary<string, Bag> { { "shiny gold", new Bag() } });

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(0);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_When1ShinyGoldBagThanContains2BagWithNoContent_ThenReturns2()
        {
            var bag = new Bag();
            bag.AddPotentialContent("dotted black", 2);
            _inputProvider.ProvideInputAsync().Returns(new Dictionary<string, Bag> { { "shiny gold", bag }, { "dotted black", new Bag() } });

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(2);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_When1ShinyGoldBagThanContains2BagWithThatContain1BagWithNoContent_ThenReturns4()
        {
            var bag1 = new Bag();
            bag1.AddPotentialContent("dotted black", 2);
            var bag2 = new Bag();
            bag2.AddPotentialContent("vibrant plum", 1);
            _inputProvider.ProvideInputAsync().Returns(new Dictionary<string, Bag> { { "vibrant plum", new Bag() }, { "shiny gold", bag1 }, { "dotted black", bag2 } });

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(4);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_When1ShinyGoldBagThanContains3BagsWithNoContentAnd2BagWithThatContain1BagWithNoContent_ThenReturns7()
        {
            var bag1 = new Bag();
            bag1.AddPotentialContent("dotted black", 2);
            bag1.AddPotentialContent("dark olive", 3);
            var bag2 = new Bag();
            bag2.AddPotentialContent("vibrant plum", 1);
            _inputProvider.ProvideInputAsync().Returns(new Dictionary<string, Bag> { { "vibrant plum", new Bag() }, { "shiny gold", bag1 }, { "dotted black", bag2 }, { "dark olive", new Bag() } });

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(7);
        }
    }
}
