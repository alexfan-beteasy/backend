using dotnet_code_challenge.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_code_challenge.Handlers
{
    public interface IHorseInfoHandler
    {
        /// <summary>
        /// get all horses in price ascending order
        /// </summary>
        /// <returns>all horses in price ascending order</returns>
        Task<IEnumerable<Horse>> GetSortedHorsesAsync();
    }
}
