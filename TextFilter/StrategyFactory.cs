using System;
using System.Collections.Generic;
using TextFilter.Interfaces;
using TextFilter.Strategies;

namespace TextFilter
{
    public class StrategyFactory: IStrategyFactory
    {
        private readonly IDictionary<string, IStrategyAction> _strategies = new Dictionary<string, IStrategyAction>();
        private const int WordsNotLessThan = 3; //config
        private const char WordsNotContainingLetter = 't'; //config
        private const string restrictedValues = "AEIOU"; // config


        public IDictionary<string, IStrategyAction> GetStrategies()
        {
            try
            {
                CreateStrategies();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Strategies Could not Be Composed: Exception {ex.StackTrace}"); // normally log
                throw;
            }

            return _strategies;
        }

        private void CreateStrategies()
        {
            _strategies.Add("VowelMiddle", new VowelMiddleStrategy(restrictedValues));
            _strategies.Add("WordsGivenLetter", new WordsGivenLetterStrategy(WordsNotContainingLetter));
            _strategies.Add("WordsGivenLength", new WordsLessGivenLengthStrategy(WordsNotLessThan));
        }
    }
}
