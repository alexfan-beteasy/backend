using dotnet_code_challenge.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_code_challenge.Handlers
{
    public interface IHorseInfoHandler
    {
        Task<IEnumerable<Horse>> GetSortedHorsesAsync();
    }
}
