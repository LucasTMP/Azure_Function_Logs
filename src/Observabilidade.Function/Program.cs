using Microsoft.Extensions.Hosting;
using Observabilidade.Function.Configurations;

namespace Observabilidade.Function
{
    public static class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    s.AddDependencyInjectionConfig();
                })
                .Build();

            host.Run();
        }
    }
}
