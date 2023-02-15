using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Clients
{
    public interface ISongClient
    {
        Task<IEnumerable<Song>> GetSongs(IEnumerable<string> artists);
    }
}
