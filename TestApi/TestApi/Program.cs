using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TestApi.Clients;
using TestApi.Services;

namespace TestApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ProgramExecution>()
                .AddTransient<SongService>()
                .AddTransient<ISongClient, SongClient>()
                .AddHttpClient()
                .BuildServiceProvider();

            var execution = serviceProvider.GetService<ProgramExecution>();

            if (execution == null)
            {
                throw new ArgumentException("Could not initialize app");
            }

            await execution.Run(args);
        }
    }
}
