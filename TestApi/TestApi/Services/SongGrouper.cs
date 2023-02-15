using System.Collections.Generic;
using System.Linq;
using TestApi.Models;

namespace TestApi.Services
{
    public static class SongGrouper
    {
        public static IEnumerable<ArtistSummary> GroupByArtist(IEnumerable<Song> songs)
        {
            var groupedSongsByArtist = songs.GroupBy(x => x.Artist);

            return groupedSongsByArtist.Select(x => new ArtistSummary(x.Key, x.Count()));
        }
    }
}
