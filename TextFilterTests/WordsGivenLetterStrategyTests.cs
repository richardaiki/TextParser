using System;
using System.Collections.Generic;
using FluentAssertions;
using TextFilter.Strategies;
using Xunit;

namespace TextFilterTests
{
    public class WordsGivenLetterStrategyTests
    {
        [Fact]
        public void WordsGivenLetter_StrategyApplied_ReturnsWhereLetterNotUsed()
        {
            var mustNotIncludeLetter = 't';
            var testWords = new List<string> { "should", "not", "include" };

            var strategy = new WordsGivenLetterStrategy(mustNotIncludeLetter);

            var result = strategy.Process(testWords);

            result[0].Should().Be("should");
            result[1].Should().Be("include");
        }

        [Fact]
        public void WordsGivenLetter_StrategyAppliedButEmptyWordListPassed_ExceptionThrow()
        {
            var mustNotIncludeLetter = 't';
            var testWords = new List<string> ();

            var strategy = new WordsGivenLetterStrategy(mustNotIncludeLetter);


            Assert.Throws<ArgumentException>(
                () =>
                {
                    strategy.Process(testWords);
                }).Message.Should().Be("Words list was empty");
        }

        [Fact]
        public void WordsGivenLetter_StrategyAppliedButEmptySearchLetterPassed_ExceptionThrow()
        {
            var mustNotIncludeLetter = new char();
            var testWords = new List<string> { "should", "not", "include" };

            var strategy = new WordsGivenLetterStrategy(mustNotIncludeLetter);


            Assert.Throws<ArgumentException>(
                () =>
                {
                    strategy.Process(testWords);
                }).Message.Should().Be("Given letter not supplied");
        }
    }
}
