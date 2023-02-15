using NUnit.Framework;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Tests.Services
{
    [TestFixture]
    public class SongGrouperTests
    {
        [Test]
        public void GroupByArtistShouldCountSongsByArtist()
        {
            var songs = new[]
            {
                new Song("No Excuses", "Alice in Chains"),
                new Song("The Drugs Don't Work", "The Verve"),
                new Song("Heaven Beside You", "Alice in Chains")
            };

            var groupedSongs = SongGrouper.GroupByArtist(songs);

            Assert.That(groupedSongs, Is.EquivalentTo(new[]
            {
                new ArtistSummary("Alice in Chains", 2),
                new ArtistSummary("The Verve", 1)
            }));
        }
    }
}
