using dotnet_code_challenge.Handlers;
using dotnet_code_challenge.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

// make it visible to unit test project but hide implementation from other projects
[assembly: InternalsVisibleTo("dotnet_code_challenge.Test")]

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadKey();
        }

        private static async Task MainAsync()
        {
            var serviceProvider = GetServiceProvider();
            var handler = serviceProvider.GetRequiredService<IHorseInfoHandler>();
            var horses = await handler.GetSortedHorsesAsync();
            Console.WriteLine("##### Horse List #####");
            Console.WriteLine(string.Join(
                Environment.NewLine,
                horses.Select(horse => $"Name: {horse.Name}, Price: {horse.Price}")
                ));
        }

        private static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddTransient<IHorseRepository, CaulfieldRaceRepository>();
            services.AddTransient<IHorseRepository, WolferhamptonRaceRepository>();
            services.AddTransient<IHorseInfoHandler, HorseInfoHandler>();
            return services.BuildServiceProvider();
        }
    }
}
