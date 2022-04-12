using Microsoft.Extensions.DependencyInjection;

namespace TextFilter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<EntryPoint>()?.Start();
        }
    }
}
