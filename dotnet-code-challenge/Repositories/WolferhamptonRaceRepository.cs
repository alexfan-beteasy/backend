using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dotnet_code_challenge.Model;
using Newtonsoft.Json.Linq;

namespace dotnet_code_challenge.Repositories
{
    internal class WolferhamptonRaceRepository : IHorseRepository
    {
        public async Task<IEnumerable<Horse>> LoadAllHorsesAsync()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "FeedData", "Wolferhampton_Race1.json");
            var jObject = JObject.Parse(await File.ReadAllTextAsync(filePath));
            var horses = jObject["RawData"]["Markets"].SelectMany(market =>
                market["Selections"].Select(selection => new Horse
                {
                    Name = selection["Tags"]["name"].Value<string>(),
                    Price = selection["Price"].Value<decimal>(),
                })
            )
            .ToList();
            return horses;
        }
    }
}
