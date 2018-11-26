using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_code_challenge.Model;
using dotnet_code_challenge.Repositories;

namespace dotnet_code_challenge.Handlers
{
    internal class HorseInfoHandler : IHorseInfoHandler
    {
        private readonly IEnumerable<IHorseRepository> horseRepositories;

        public HorseInfoHandler(IEnumerable<IHorseRepository> horseRepositories)
        {
            this.horseRepositories = horseRepositories;
        }

        public async Task<IEnumerable<Horse>> GetSortedHorsesAsync()
        {
            var horses = Enumerable.Empty<Horse>();
            foreach(var horseRepository in horseRepositories)
            {
                horses = horses.Concat((await horseRepository.LoadAllHorsesAsync()) ?? Enumerable.Empty<Horse>());
            }
            return horses.OrderBy(horse => horse.Price).ToList();
        }
    }
}
