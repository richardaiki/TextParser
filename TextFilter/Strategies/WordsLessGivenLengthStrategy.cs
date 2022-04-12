using System;
using System.Collections.Generic;
using System.Linq;
using TextFilter.Interfaces;

namespace TextFilter.Strategies
{
    public class WordsLessGivenLengthStrategy: IStrategyAction
    {
        private readonly int _wordsNotLessThan;

        public WordsLessGivenLengthStrategy(int wordsNotLessThan)
        {
            _wordsNotLessThan = wordsNotLessThan;
        }

        public IList<string> Process(IList<string> words)
        {
            if (words.Count == 0)
            {
                throw new ArgumentException("Words list was empty");
            }

            if (_wordsNotLessThan == 0) // some arb range needed
            {
                throw new ArgumentException("Given length not supplied");
            }

            if (_wordsNotLessThan < 0) // some arb range needed
            {
                throw new ArgumentException("Given length cannot be negative");
            }

            return words.Where(word => word.Length >= _wordsNotLessThan).ToList();

           
        }
    }
}
