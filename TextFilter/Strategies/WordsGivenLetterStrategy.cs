using System;
using System.Collections.Generic;
using System.Linq;
using TextFilter.Interfaces;

namespace TextFilter.Strategies
{
    public class WordsGivenLetterStrategy: IStrategyAction
    {
        private readonly char _wordsNotContainingLetter;

        public WordsGivenLetterStrategy(char wordsNotContainingLetter)
        {
            _wordsNotContainingLetter = wordsNotContainingLetter;
        }

        public IList<string> Process(IList<string> words)
        {
            if (words.Count == 0)
            {
                throw new ArgumentException("Words list was empty");
            }

            if (_wordsNotContainingLetter == new char())
            {
                throw new ArgumentException("Given letter not supplied");
            }

            return words.Where(word => !word.Contains(_wordsNotContainingLetter)).ToList();
        }
    }
}
