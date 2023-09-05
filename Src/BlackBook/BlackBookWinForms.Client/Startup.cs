using Mega.Client;
using MegaService;
using Microsoft.Extensions.DependencyInjection;


namespace BlackBookWinForms.Client
{
    public static class Startup
    {
        public static IServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMegaClient, MegaClient>()
                .AddSingleton<IMegaService, MegaService.MegaService>()                
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
