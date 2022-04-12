using System;
using System.Collections.Generic;
using FluentAssertions;
using TextFilter.Strategies;
using Xunit;

namespace TextFilterTests
{
    public class VowelMiddleStrategyTests
    {
        [Fact]
        public void VowelMiddleStrategy_GivenThreeWordsOneWithMiddleLetterVowel_ReturnsNonMiddleLetterVowelWords()
        {

            var testWords = new List<string> { "Any", "not", "include" };
            var restrictedValues = "AEIOU";

            var strategy = new VowelMiddleStrategy(restrictedValues);

            var result = strategy.Process(testWords);

            result[0].Should().Be("Any");
            result[1].Should().Be("include");
        }

        [Fact]
        public void VowelMiddleStrategy_GivenThreeWordsOneWithMiddleLettersVowel_ReturnsNonMiddleLettersVowelWords()
        {

            var testWords = new List<string> { "Any", "peer", "include" };
            var restrictedValues = "AEIOU";

            var strategy = new VowelMiddleStrategy(restrictedValues);

            var result = strategy.Process(testWords);

            result[0].Should().Be("Any");
            result[1].Should().Be("include");
        }


        [Fact]
        public void VowelMiddleStrategy_GivenNoWords_ExceptionIsThrown()
        {

            var testWords = new List<string> ();
            var restrictedValues = "AEIOU";

            var strategy = new VowelMiddleStrategy(restrictedValues);

            Assert.Throws<ArgumentException>(
                () =>
                {
                    strategy.Process(testWords);
                }).Message.Should().Be("Words list was empty");
        }

        [Fact]
        public void VowelMiddleStrategy_GivenEmptyVowels_ExceptionIsThrown()
        {

            var testWords = new List<string> { "Any", "peer", "include" };
            var restrictedValues = string.Empty;

            var strategy = new VowelMiddleStrategy(restrictedValues);

            Assert.Throws<ArgumentException>(
                () =>
                {
                    strategy.Process(testWords);
                }).Message.Should().Be("Restricted chars (Vowels) was empty");
        }


    }
}
