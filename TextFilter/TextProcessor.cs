using System.Collections.Generic;
using System.Text;
using TextFilter.Interfaces;

namespace TextFilter
{
    public class TextProcessor: ITextProcessor
    {
        public IList<string> Process(IList<string> words, IDictionary<string, IStrategyAction> strategies)
        {
            var validWords = words;

            foreach (var strategy in strategies)
            {
                validWords = strategy.Value.Process(validWords);
            }

            return validWords;
        }

        public string ConvertToOutput(IList<string> output)
        {
            return string.Join(' ', output);
        }

        public IList<string> Split(string rawString)
        {
            return rawString.Split(' ');
        }

        public string ReformatText(string originalText)  // some . don't have space before next word
        {
            var processedCharacters = new StringBuilder();

            for (var i = 0; i < originalText.Length; i++)
            {
                processedCharacters.Append(originalText[i]);

                if (originalText[i].ToString() != ".") continue;

                if (i == originalText.Length-1) continue;

                if (originalText[i + 1].ToString() != " ")
                {
                    processedCharacters.Append(" ");
                }
            }

            return processedCharacters.ToString();
        }
    }
}
