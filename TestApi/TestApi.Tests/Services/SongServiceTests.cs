using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestApi.Clients;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Tests.Services
{
    [TestFixture]
    public class SongServiceTests
    {
        [Test]
        public async Task GetFormattedSongsShouldRetrieveSongsAndFormatGroupsByArtist()
        {
            var clientMock = new Mock<ISongClient>();
            clientMock
                .Setup(x => x.GetSongs(It.IsAny<IEnumerable<string>>()))
                .ReturnsAsync(new[]
                {
                    new Song("39", "Queen"),
                    new Song("Second Hand News", "Fleetwood Mac"),
                    new Song("Monday Morning", "Fleetwood Mac")
                });

            var service = new SongService(clientMock.Object);

            var formattedOutput = await service.GetFormattedSongs(new[] { "Queen", "Fleetwood Mac" });

            var expectedOutput = @"Artist: Queen, Count: 1
Artist: Fleetwood Mac, Count: 2
";
            
            Assert.That(formattedOutput, Is.EqualTo(expectedOutput));
        }
    }
}
