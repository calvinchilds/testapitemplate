using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApi.Clients;

namespace TestApi.Services
{
    public class SongService
    {
        private readonly ISongClient _songClient;

        public SongService(ISongClient songClient)
        {
            _songClient = songClient;
        }

        public async Task<string> GetFormattedSongs(IEnumerable<string> artists)
        {
            var songs = await _songClient.GetSongs(artists);

            var stringBuilder = new StringBuilder();
            
            foreach (var (artist, count) in SongGrouper.GroupByArtist(songs))
            {
                stringBuilder.AppendLine($"Artist: {artist}, Count: {count}");
            }

            return stringBuilder.ToString();
        }
    }
}
