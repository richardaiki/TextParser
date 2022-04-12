using System.Collections.Generic;
using FluentAssertions;
using TextFilter;
using TextFilter.Interfaces;
using TextFilter.Strategies;
using Xunit;

namespace TextFilterTests
{
    public class StrategyFactoryTests
    {
        [Fact]
        public void StrategyFactory_GetStrategies_ReturnsPopulatedStrategies()
        {
            var expected = new Dictionary<string,IStrategyAction>();
            int WordsNotLessThan = 3; 
            char WordsNotContainingLetter = 't';
            string restrictedList = "AEIOU";

            expected.Add("VowelMiddle", new VowelMiddleStrategy(restrictedList));
            expected.Add("WordsGivenLetter", new WordsGivenLetterStrategy(WordsNotContainingLetter));
            expected.Add("WordsGivenLength", new WordsLessGivenLengthStrategy(WordsNotLessThan));

            var factory = new StrategyFactory();

            var result = factory.GetStrategies();

            foreach (var item in expected)
            {
                var found = result[item.Key];
                var tempType = item.Value.GetType();

                found.Should().BeOfType(tempType);
            }
        }
    }
}
