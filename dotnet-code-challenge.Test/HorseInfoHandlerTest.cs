using dotnet_code_challenge.Handlers;
using dotnet_code_challenge.Model;
using dotnet_code_challenge.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class HorseInfoHandlerTest
    {
        [Fact]
        public async Task GetSortedHorsesAsync_WhenRepositoryReturnsNull_ReturnEmptyCollection()
        {
            var repositoryMock = new Mock<IHorseRepository>();
            repositoryMock.Setup(item => item.LoadAllHorsesAsync()).Returns(Task.FromResult<IEnumerable<Horse>>(null));
            var handler = new HorseInfoHandler(new[] { repositoryMock.Object });
            var result = await handler.GetSortedHorsesAsync();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetSortedHorsesAsync_WhenHavingMultipleRepositories_ReturnSortedAggragatedCollection()
        {
            var horse1 = new Horse { Name = "horse 1", Price = 1 };
            var horse2 = new Horse { Name = "horse 2", Price = 2 };
            var horse3 = new Horse { Name = "horse 3", Price = 3 };

            var repositoryMock1 = new Mock<IHorseRepository>();
            repositoryMock1.Setup(item => item.LoadAllHorsesAsync()).Returns(Task.FromResult<IEnumerable<Horse>>(new[] { horse2 }));
            var repositoryMock2 = new Mock<IHorseRepository>();
            repositoryMock2.Setup(item => item.LoadAllHorsesAsync()).Returns(Task.FromResult<IEnumerable<Horse>>(new[] { horse3, horse1 }));
            var handler = new HorseInfoHandler(new[] { repositoryMock1.Object, repositoryMock2.Object });
            var result = await handler.GetSortedHorsesAsync();
            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(new[] { horse1, horse2, horse3 }));
        }
    }
}
