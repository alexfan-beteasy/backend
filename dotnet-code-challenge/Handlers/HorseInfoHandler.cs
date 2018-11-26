using System;
using System.Collections.Generic;
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

        public Task<IEnumerable<Horse>> GetSortedHorsesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
