using System;
using System.Collections.Generic;
using FluentAssertions;
using TextFilter.Strategies;
using Xunit;

namespace TextFilterTests
{
    public class WordsGivenLengthStrategyTests
    {
        [Fact]
        public void WordsGivenLength_StrategyApplied_ReturnsWhereLengthNotLessThanGivenValue()
        {
            var wordLengthNotLessThan = 3;
            var testWords = new List<string> { "should", "be", "final" };

            var strategy = new WordsLessGivenLengthStrategy(wordLengthNotLessThan); 

            var result = strategy.Process(testWords);

            result[0].Should().Be("should");
            result[1].Should().Be("final");
        }

        [Fact]
        public void WordsGivenLength_StrategyApplied_ThrowsExceptionWhenLengthNotLessThanUnset()
        {
            var wordLengthNotLessThan = 0;
            var testWords = new List<string> { "should", "be", "final" };

            var strategy = new WordsLessGivenLengthStrategy(wordLengthNotLessThan);

            Assert.Throws<ArgumentException>(
                () =>
                {
                    strategy.Process(testWords);
                }).Message.Should().Be("Given length not supplied");

        }

        [Fact]
        public void WordsGivenLength_StrategyApplied_ThrowsExceptionWhenLengthNotLessThanISNegative()
        {
            var wordLengthNotLessThan = -1;
            var testWords = new List<string> { "should", "be", "final" };

            var strategy = new WordsLessGivenLengthStrategy(wordLengthNotLessThan);

            Assert.Throws<ArgumentException>(
                () =>
                {
                    strategy.Process(testWords);
                }).Message.Should().Be("Given length cannot be negative");

        }
    }
}
