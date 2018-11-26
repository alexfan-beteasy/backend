using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.Repositories
{
    internal class CaulfieldRaceRepository : IHorseRepository
    {
        public async Task<IEnumerable<Horse>> LoadAllHorsesAsync()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "FeedData", "Caulfield_Race1.xml");
            using(var fs = File.OpenRead(filePath))
            {
                var horses = Enumerable.Empty<Horse>();
                var doc = await XDocument.LoadAsync(fs, LoadOptions.None, CancellationToken.None);
                var raceNodes = doc.XPathSelectElements("meeting/races/race");
                foreach (var raceNode in raceNodes)
                {
                    var numberAndPriceDictionary = raceNode.XPathSelectElements("prices/price/horses/horse").ToDictionary(
                        node => node.Attribute("number").Value,
                        node => Convert.ToDecimal(node.Attribute("Price").Value)
                        );

                    var horsesOfRace = raceNode.XPathSelectElements("horses/horse").Select(node => new Horse
                    {
                        Name = node.Attribute("name").Value,
                        Price = numberAndPriceDictionary[node.Element("number").Value],
                    });

                    horses = horses.Concat(horsesOfRace);
                }

                return horses.ToList();
            }
        }
    }
}
