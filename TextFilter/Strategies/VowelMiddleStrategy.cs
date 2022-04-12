using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using TextFilter.Interfaces;

namespace TextFilter.Strategies
{
    public class VowelMiddleStrategy: IStrategyAction
    {
        private readonly string _vowels;

        public VowelMiddleStrategy(string vowels)
        {
            _vowels = vowels.ToLower(CultureInfo.InvariantCulture);
        }

        public IList<string> Process(IList<string> words)
        {

            if (words.Count == 0)
            {
                throw new ArgumentException("Words list was empty");
            }

            if (_vowels.Length == 0)
            {
                throw new ArgumentException("Restricted chars (Vowels) was empty");
            }

            var validWords = new List<string>();

            foreach (var word in words)
            {
                var resolvedWord = RemoveNonAlphaChars(word);

                if (resolvedWord.Length % 2 == 0)
                {
                    var left = resolvedWord.Length / 2;
                    var right = left + 1;

                    if (!IsVowel(resolvedWord[left-1], resolvedWord[right-1]))
                    {
                        validWords.Add(word);
                    }
                }
                else
                {
                    if (!IsVowel(resolvedWord[resolvedWord.Length/2]))
                    {
                        validWords.Add(word);
                    }
                }
            }

            return validWords;
        }

        private string RemoveNonAlphaChars(string word)
        {
            return Regex.Replace(word, "[^a-zA-Z]", string.Empty);
        }

        private bool IsVowel(char testChar)
        {
            return _vowels.Contains(testChar.ToString().ToLower(CultureInfo.InvariantCulture));
        }

        private bool IsVowel(char testCharLeft, char testCharRight)
        {
            return IsVowel(testCharLeft) || IsVowel(testCharRight);
        }
    }
}
