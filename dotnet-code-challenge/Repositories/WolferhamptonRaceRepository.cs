using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.Repositories
{
    internal class WolferhamptonRaceRepository : IHorseRepository
    {
        public Task<IEnumerable<Horse>> LoadAllHorsesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
