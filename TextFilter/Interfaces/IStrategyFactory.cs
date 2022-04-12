using System.Collections.Generic;

namespace TextFilter.Interfaces
{
    public interface IStrategyFactory
    {
        IDictionary<string, IStrategyAction> GetStrategies();
    }
}
