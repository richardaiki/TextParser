using System.Collections.Generic;

namespace TextFilter.Interfaces
{
    public interface ITextProcessor
    {
        string ReformatText(string originalText);

        IList<string> Process(IList<string> words, IDictionary<string, IStrategyAction> strategies);

        string ConvertToOutput(IList<string> output);

        IList<string> Split(string rawString);
    }
}
