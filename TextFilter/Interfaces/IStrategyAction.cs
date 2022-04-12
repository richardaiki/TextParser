using System.Collections.Generic;

namespace TextFilter.Interfaces
{
    public interface IStrategyAction
    {
        IList<string> Process(IList<string> words);
    }
}
