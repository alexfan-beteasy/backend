using dotnet_code_challenge.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class WolferhamptonRaceRepositoryTest
    {
        [Fact]
        public async Task LoadAllHorsesAsync_ReturnSampleResult()
        {
            var repository = new WolferhamptonRaceRepository();
            var result = (await repository.LoadAllHorsesAsync())?.ToList();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result.Count(horse => horse.Name == "Toolatetodelegate" && horse.Price == 10.0m));
            Assert.Equal(1, result.Count(horse => horse.Name == "Fikhaar" && horse.Price == 4.4m));
        }
    }
}
