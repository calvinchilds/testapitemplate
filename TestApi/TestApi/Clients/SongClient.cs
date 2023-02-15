using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Clients
{
    public class SongClient : ISongClient
    {
        private readonly HttpClient _httpClient;
        
        public SongClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IEnumerable<Song>> GetSongs(IEnumerable<string> artists)
        {
            var artistRequests = string.Join(',', artists.Select(x => $"\"{x}\""));

            var songsJson = await _httpClient.GetStringAsync(
                    $"https://www.songsterr.com/a/ra/songs/byartists.json?artists={artistRequests}");

            var songResponses = JsonSerializer.Deserialize<IEnumerable<SongResponse>>(songsJson);

            if (songResponses == null)
            {
                throw new ArgumentException($"Could not deserialize response {songsJson}");
            }

            return songResponses.Select(x => new Song(x.title, x.artist.name));
        }

        private class SongResponse
        {
            public string title { get; set; }
            public ArtistResponse artist { get; set; }
        }

        private class ArtistResponse
        {
            public string name { get; set; }
        }
    }
}
