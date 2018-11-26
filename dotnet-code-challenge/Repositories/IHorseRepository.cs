using dotnet_code_challenge.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_code_challenge.Repositories
{
    public interface IHorseRepository
    {
        Task<IEnumerable<Horse>> LoadAllHorsesAsync();
    }
}
