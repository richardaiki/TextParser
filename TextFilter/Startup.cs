using Microsoft.Extensions.DependencyInjection;
using TextFilter.Interfaces;

namespace TextFilter
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<EntryPoint>();
            services.AddSingleton<ITextFileReader, TextFileReader>();
            services.AddSingleton<IStrategyFactory, StrategyFactory>();
            services.AddSingleton<ITextProcessor, TextProcessor>();

            return services;
        }
    }
}
