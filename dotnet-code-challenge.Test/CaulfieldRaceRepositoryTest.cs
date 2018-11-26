using dotnet_code_challenge.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class CaulfieldRaceRepositoryTest
    {
        [Fact]
        public async Task LoadAllHorsesAsync_ReturnSampleResult()
        {
            var repository = new CaulfieldRaceRepository();
            var result = (await repository.LoadAllHorsesAsync())?.ToList();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result.Count(horse => horse.Name == "Advancing" && horse.Price == 4.2m));
            Assert.Equal(1, result.Count(horse => horse.Name == "Coronel" && horse.Price == 12m));
        }
    }
}
